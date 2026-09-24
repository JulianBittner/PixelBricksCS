using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace PixelBricksCS.Engine.Audio
{
  internal interface IAudioHandle
  {
    public void PlaySound(ISampleProvider sample);
  }
}
