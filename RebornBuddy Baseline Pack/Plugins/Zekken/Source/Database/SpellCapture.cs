using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ff14bot;

namespace Zekken
{
    public class SpellCapture
    {
        private object locker = new object();
        private const uint WM_KEYDOWN = 0x100;
        private const uint WM_KEYUP = 0x0101;
        private IntPtr windowHandle;
        private const int WAIT_BEFORE_SCREENSHOT = 300;

        public SpellCapture()
        {
            FileTools.PrepareDirectory(Directories.DEFAULT_SCREENSHOT_DIR);
            windowHandle = Core.Memory.Process.MainWindowHandle;
        }

        public void CaptureScreenshot(uint spellId, string spellname)
        {
            var name = string.Format("{0} ({1})", spellname, spellId);
            Task.Run(() => TakeScreenshot(name));
        }

        private void TakeScreenshot(string name)
        {
            ToggleUi();
            Thread.Sleep(WAIT_BEFORE_SCREENSHOT);

            Logger.WriteMessage("Taking screenshot of unknown spell {0}.",name);

            Bitmap image;
            try { image = Capture(); }
            catch { image = null; }

            Thread.Sleep(200);
            ToggleUi();
            if (image == null) { return; }

            var path = Path.Combine(Directories.DEFAULT_SCREENSHOT_DIR, name + ".png");
			
			if (!FileTools.Save(path,image,(stream,data)=>{data.Save(stream,ImageFormat.Png);}))
			{
               Logger.WriteError("Failed to save screenshot to: {0}.",path);
			   
			   return;
			}

            Logger.WriteMessage("Saved unknown spell {0} screenshot to: {1}.", name,path);
        }

        private void ToggleUi()
        {
            PostMessage(windowHandle, WM_KEYDOWN, (IntPtr)(Keys.Scroll), IntPtr.Zero);
            PostMessage(windowHandle, WM_KEYUP, (IntPtr)(Keys.Scroll), IntPtr.Zero);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private static Bitmap Capture()
        {
            var bounds = Screen.PrimaryScreen.Bounds;
            var bitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format16bppRgb555);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 bitmap.Size,
                                 CopyPixelOperation.SourceCopy);
            }

            Logger.WriteMessage("Screenshot size: {0}.", bitmap.Size);
            return bitmap;
        }
    }
}
