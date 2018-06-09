using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using ConfirmationDialogs;
using System.Windows.Media.Imaging;
using OptionalSharp;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace Tests {
	internal class Program {
		[STAThread]
		public static void Main(string[] args) {
			List<Color> colors = new List<Color>(){Colors.White};
			WriteableBitmap  writableBitmap= new WriteableBitmap(100,100,10,10,PixelFormats.Bgr32,new BitmapPalette(colors));
			Int32Rect r= new Int32Rect(0,0,100,100);
			int stride = (r.Width * writableBitmap.Format.BitsPerPixel + 7) / 8;
			int bufferSize = r.Height * stride;
			byte[] sourceBuffer = new byte[bufferSize];
			for (int i = 0; i < sourceBuffer.Length; i++) {
				sourceBuffer[i] = 0;
				i++;
				sourceBuffer[i] = 66;
				i++;
				sourceBuffer[i] = 134;
				i++;
				sourceBuffer[i] = 244;
			}
			writableBitmap.WritePixels(sourceRect: r,pixels: sourceBuffer,stride: stride,offset: 0);
			ConfirmationSettings.ConfirmByRetyping = true;
			Console.WriteLine(Confirmation.Confirm(
				confirmByRetyping:
				false,icon: writableBitmap /*"dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh dfghjogtftfzu utfzzfzigfozigfo zgfghzghhggh "*/));
			Console.Read();
		}
	}
}