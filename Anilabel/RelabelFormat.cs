using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anilabel
{
    public sealed class RelabelFormat
    {
        private readonly string format;
        private readonly int value;

        public static readonly RelabelFormat InvalidFormat = new RelabelFormat(-1, string.Empty);
        public static readonly RelabelFormat TitleBasedFormat = new RelabelFormat(0, "Anime - Episode - [Resolution][Subber] (raw)");
        public static readonly RelabelFormat SubberBasedFormat = new RelabelFormat(1, "[Subber] Anime - Episode - [Resolution] (raw)");
        public static readonly RelabelFormat DetailBasedFormat = new RelabelFormat(2, "[Subber][Resolution] - Anime - Episode (raw)");

        private RelabelFormat(int value, string format)
        {
            this.value = value;
            this.format = format;
        }

        public override String ToString()
        {
            return this.format;
        }

        public int ToIndex()
        {
            return this.value;
        }
    }
}
