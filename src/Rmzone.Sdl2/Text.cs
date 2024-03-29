

namespace Rmzone.Sdl2
{
    public sealed class Text
    {
        private readonly Renderer _renderer;
        private Texture _font;

        private int _charWidth;
        private int _charHeight;
        private int _nbCharWidth;
        private int _nbCharHeight; // use so we don't go past the end.
        private int _charOffset;

        public Text(Renderer renderer)
        {
            _renderer = renderer;
        }

        public void LoadFont(string path)
        {
            _font = new Texture(_renderer, path);

            _charWidth = 16;
            _charHeight = 16;
            _nbCharWidth = 256 / _charWidth;
            _nbCharHeight = 256 / _charHeight;
            _charOffset = 0;
        }

        public void DrawString(string text, int x, int y, RgbaByte color)
        {
            var i = 0;

            foreach (var c in text)
            {
                var ascii = (int) c;
                ascii -= _charOffset;
                var xSrc = ascii % _nbCharWidth * _charWidth;
                var ySrc = ascii / _nbCharWidth * _charHeight;

                var srcRect = new Rectangle(xSrc, ySrc, _charWidth, _charHeight);
                var dstRect = new Rectangle(x + i * _charWidth, y, _charWidth, _charHeight);

                _font.Render(srcRect, dstRect, color);

                i++;
            }
        }

        public void LoadDefaultFont(int scale)
        {
            _font = new Texture(_renderer, 0, Texture.TextureAccess.Streaming, 128*scale, 48*scale);
//            var size = 128 * 48 * scale * scale;
//            var buffer = new RgbaByte[size];

            var data = "?Q`0001oOch0o01o@F40o0<AGD4090LAGD<090@A7ch0?00O7Q`0600>00000000";
            data += "O000000nOT0063Qo4d8>?7a14Gno94AA4gno94AaOT0>o3`oO400o7QN00000400";
            data += "Of80001oOg<7O7moBGT7O7lABET024@aBEd714AiOdl717a_=TH013Q>00000000";
            data += "720D000V?V5oB3Q_HdUoE7a9@DdDE4A9@DmoE4A;Hg]oM4Aj8S4D84@`00000000";
            data += "OaPT1000Oa`^13P1@AI[?g`1@A=[OdAoHgljA4Ao?WlBA7l1710007l100000000";
            data += "ObM6000oOfMV?3QoBDD`O7a0BDDH@5A0BDD<@5A0BGeVO5ao@CQR?5Po00000000";
            data += "Oc``000?Ogij70PO2D]??0Ph2DUM@7i`2DTg@7lh2GUj?0TO0C1870T?00000000";
            data += "70<4001o?P<7?1QoHg43O;`h@GT0@:@LB@d0>:@hN@L0@?aoN@<0O7ao0000?000";
            data += "OcH0001SOglLA7mg24TnK7ln24US>0PL24U140PnOgl0>7QgOcH0K71S0000A000";
            data += "00H00000@Dm1S007@DUSg00?OdTnH7YhOfTL<7Yh@Cl0700?@Ah0300700000000";
            data += "<008001QL00ZA41a@6HnI<1i@FHLM81M@@0LG81?O`0nC?Y7?`0ZA7Y300080000";
            data += "O`082000Oh0827mo6>Hn?Wmo?6HnMb11MP08@C11H`08@FP0@@0004@000000000";
            data += "00P00001Oab00003OcKP0006@6=PMgl<@440MglH@000000`@000001P00000000";
            data += "Ob@8@@00Ob@8@Ga13R@8Mga172@8?PAo3R@827QoOb@820@0O`0007`0000007P0";
            data += "O`000P08Od400g`<3V=P0G`673IP0`@3>1`00P@6O`P00g`<O`000GP800000000";
            data += "?P9PL020O`<`N3R0@E4HC7b0@ET<ATB0@@l6C4B0O`H3N7b0?P01L3R000000020";

            var px = 0;
            var py = 0;

            for (var b = 0; b < 1024; b += 4)
            {
                var sym1 = (uint)data[b + 0] - 48;
                var sym2 = (uint)data[b + 1] - 48;
                var sym3 = (uint)data[b + 2] - 48;
                var sym4 = (uint)data[b + 3] - 48;
                var r = sym1 << 18 | sym2 << 12 | sym3 << 6 | sym4;

                for (var i = 0; i < 24; i++)
                {
                    byte k = (r & (1 << i)) != 0 ? (byte)0xff : (byte)0x00;

                    // take into account scale
                    var pxl = new RgbaByte(k, k, k, k);
                    _font.SetPixel(px, py, pxl);

                    if (scale > 1)
                    {
                        _font.SetPixel(px+1, py, pxl);
                        _font.SetPixel(px, py+1, pxl);
                        _font.SetPixel(px+1, py+1, pxl);
                    }

                    py += scale;
                    if (py == (48 * scale))
                    {
                        px += scale;
                        py = 0;
                    }
                }
            }

            _charWidth = 8 * scale;
            _charHeight = 8 * scale;
            _nbCharWidth = (128 * scale) / _charWidth;
            _nbCharHeight = (48  * scale) / _charHeight;
            _charOffset = 32;
        }
    }
}
