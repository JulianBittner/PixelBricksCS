using PixelBricksCS.Engine.Composing;
using PixelBricksCS.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Rendering
{
  internal class Renderer
  {
    private readonly record struct RenderEntry(IComposer Composer, GridPosition Position) {}
    
    private readonly List<RenderEntry> _dynamicRenderEntries = new();
    private readonly List<RenderEntry> _staticRenderEntries = new();
    private readonly FrameBuffer _frameBuffer;

    public FrameBuffer TargetBuffer => _frameBuffer;

    public Renderer(FrameBuffer frameBuffer) { 
      _frameBuffer = frameBuffer;
    }

    public void AddDynamicComposer(IComposer composer, GridPosition position) {
      _dynamicRenderEntries.Add(new RenderEntry(composer, position));
    }

    public void AddStaticComposer(IComposer composer, GridPosition position) {
      _staticRenderEntries.Add(new RenderEntry(composer, position));
    }

    public void RenderDynamicContent() {
      foreach (var renderEntry in _dynamicRenderEntries) {
        renderEntry.Composer.Compose(_frameBuffer, renderEntry.Position);
      }
    }
    public void RenderStaticContent() {
      foreach(var renderEntry in _staticRenderEntries) {
        renderEntry.Composer.Compose(_frameBuffer, renderEntry.Position);
      }
    }
  }
}
