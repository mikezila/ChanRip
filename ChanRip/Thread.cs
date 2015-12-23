using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChanRip
{
    struct Post
    {
        private string TrueFilename { get { return tim + ext; } }
        private string ThumbFilename { get { return tim + "s.jpg"; } }
        public string board;
        public string vanityFilename;

        public string UniqueFileName
        {
            get
            {
                return tim + ext;
            }
        }

        public string ThumbURL
        {
            get
            {
                return "http://i.4cdn.org/" + board + "/" + ThumbFilename;
            }
        }

        public string ImageURL
        {
            get
            {
                return "http://i.4cdn.org/" + board + "/" + TrueFilename;
            }
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool vanity)
        {
            if (vanity)
                return vanityFilename + ext;
            else
                return tim + ext;
        }

        public string tim;
        public string ext;
    }

    [Serializable]
    class Thread : IComparable<Thread>
    {
        private string TrueFilename { get { return tim + ext; } }
        private string ThumbFilename { get { return tim + "s.jpg"; } }
        public string Title
        {
            get
            {
                if (sub == null)
                    return semantic_url;
                else
                    return sub;
            }
        }

        public string ThumbURL
        {
            get
            {
                return "http://i.4cdn.org/" + board + "/" + ThumbFilename;
            }
        }

        public string ImageURL
        {
            get
            {
                return "http://i.4cdn.org/" + board + "/" + TrueFilename;
            }
        }

        public string board;
        public bool dead = false;

        public int no;
        public int images;
        public string semantic_url;
        public string sub;
        public string com;
        public string ext;
        public string tim;

        private string URL(string board)
        {
            return "http://a.4cdn.org/" + board + "/" + no.ToString() + ".json";
        }

        public override string ToString()
        {
            return images.ToString() + " " + Title;
        }

        public int CompareTo(Thread other)
        {
            if (other.images > images)
                return 1;
            else if (other.images == images)
                return 0;
            else
                return -1;
        }
    }
}
