using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChanRip
{
    static class Chomper
    {
        public static void UpdateThreads()
        {
            if (!File.Exists("4chompmeta"))
                return;

            var folders = Directory.GetDirectories(".");
            foreach (var folder in folders)
            {
                if (File.Exists(folder + "/meta"))
                {
                    Thread thread;
                    using (var metaFile = File.Open("/meta",FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        thread = (Thread)bin.Deserialize(metaFile);
                    }

                    if (thread.dead)
                        continue;

                    List<string> imageLinks = new List<string>();
                    try
                    {
                        imageLinks = GetImageLinks(meta);
                    }
                    catch (Exception)
                    {
                        output.AppendText("Marking " + folder + " as dead thread" + Environment.NewLine);
                        File.WriteAllText(folder + "/meta", "dead");
                        continue;
                    }

                    output.AppendText("Updating thread " + meta.Slug() + Environment.NewLine);
                    try
                    {
                        RipImages(meta.Slug(), imageLinks, output);
                    }
                    catch (Exception)
                    {
                        output.AppendText("Exception!  Did you grab the right link?");
                    }

                }
            }
        }

        public static void RipNewThread(string threadURL, TextBox output)
        {
            // Get URL slug for unique folder name.
            output.Clear();
            string slug = threadURL.Slug();
            var imageURLs = GetImageLinks(threadURL);

            if (Directory.Exists(slug) && File.ReadAllText(slug + "/meta") != "dead")
            {
                output.Text = "\nThread is already ripped and not dead.  Try update instead.";
                return;
            }

            output.AppendText("Ripping thread " + slug + "..." + Environment.NewLine);
            Directory.CreateDirectory(slug);
            using (var writer = File.CreateText(slug + "/meta"))
            {
                writer.WriteLine(threadURL);
            }

            RipImages(slug, imageURLs, output);


        }

        static void RipImages(string slug, List<string> imageURLs)
        {
            using (WebClient client = new WebClient())
                foreach (string link in imageURLs)
                {
                    Application.DoEvents();
                    if (!File.Exists(Directory.GetCurrentDirectory() + "/" + slug + "/" + link.Slug()))
                    {
                        try
                        {
                            client.DownloadFile(link, slug + "/" + link.Slug());
                        }
                        catch (WebException)
                        {

                        }
                    }
                }
        }
    }
}
