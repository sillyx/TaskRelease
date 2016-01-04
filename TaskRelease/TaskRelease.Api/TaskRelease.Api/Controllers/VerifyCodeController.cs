using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TaskRelease.Api.Controllers
{
    public class VerifyCodeController : Controller
    {

        public ActionResult Index()
        {
            string randomString;
            var file = NewCaptchaImage(120, 40, ImageFormat.Jpeg, out randomString);
            Session["code"] = randomString;
            return File(file, "image/jpeg");
        }


        public static byte[] NewCaptchaImage(int width, int height, ImageFormat imageFormat, out string randomString)
        {
            var r = new Random();
            var c = new StringBuilder();

            for (var i = 0; i < 4; i++)
            {
                c.Append((char)r.Next(65, 91));
            }

            randomString = c.ToString();

            using (var b = new Bitmap(width, height))
            {
                using (var g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.FillRectangle(Brushes.Gainsboro, 0, 0, width, height);

                    for (var i = 0; i < 50; i++)
                    {
                        using (
                            var s =
                                new SolidBrush(
                                    Color.FromArgb(200, r.Next(100, 225), r.Next(100, 225), r.Next(100, 225))))
                        {
                            g.FillEllipse(s, r.Next(width - 5), r.Next(height - 5), 2, 2);
                        }
                    }

                    var w = (width - 12) / c.Length;
                    var h = height - 12;

                    for (var i = 0; i < c.Length; i++)
                    {
                        var x = w * (i + 0.5f) + r.Next(2, 6);
                        var y = height * 0.5f + r.Next(-4, 4);
                        var f = Math.Min(w, h) * 0.8f;

                        using (var m = new Matrix())
                        {
                            m.RotateAt(r.Next(-60, 60), new PointF(x, y));
                            g.Transform = m;

                            using (
                                var s = new SolidBrush(Color.FromArgb(r.Next(1, 150), r.Next(1, 150), r.Next(1, 150))))
                            {
                                g.DrawString(
                                    c.ToString(i, 1), new Font("宋体", f, FontStyle.Bold), s, x - f * 0.5f, y - f * 0.5f);
                            }
                        }
                    }
                }

                using (var m = new MemoryStream())
                {
                    b.Save(m, imageFormat);
                    m.Position = 0;
                    using (var n = new BinaryReader(m))
                    {
                        return n.ReadBytes((int)m.Length);
                    }
                }
            }
        }

        [HttpPost]
        public JsonResult CheckCode(string code)
        {
            if (string.Compare(Session["code"].ToString(), code, true) == 0)
            {
                return Json(true);
            }
            return Json(false);
        }

    }
}
