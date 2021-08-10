using System;
using System.IO;

namespace olepunchy.Services {

    public class MarkDownService {

        // NOTE: Read all of the markdown files
        public void ReadMarkdownFiles() {

            foreach (string file in Directory.EnumerateFiles("Blog/Markdown", "*.md")) {
                // TODO: For now just console log the contents.
                string contents = File.ReadAllText(file);

                Console.WriteLine(contents);
            }
        }

        // NOTE: For each makrdown file, convert to html
        public void ConvertMarkDownToHtml() {

        }

        // TODO: Print a summarized list of the files

        // TODO: Order the files by date descending

        // TODO: Search the files for a keyword or term
    }
}
