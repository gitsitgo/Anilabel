using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Anilabel
{

    public class AnimeVideo
    {
        private string subber;
        private string subberMatch;
        private string anime;
        private string resolution;
        private string resolutionMatch;
        private string raw;
        private string rawMatch;

        public AnimeVideo(string filename)
        {
            string regexMatchValue = string.Empty;
            this.resolution = ParseResolution(filename, out regexMatchValue);
            this.resolutionMatch = regexMatchValue;
            this.subber = ParseSubber(filename, out regexMatchValue);
            this.subberMatch = regexMatchValue;
            this.raw = ParseRaw(filename, out regexMatchValue);
            this.rawMatch = regexMatchValue;
            this.anime = ParseAnime(filename);
        }

        public string Subber
        { get { return this.subber; } }
        public string SubberMatch
        { get { return this.subberMatch; } }
        public string Anime
        { get { return this.anime; } }
        public string Resolution
        { get { return this.resolution; } }
        public string ResolutionMatch
        { get { return this.resolutionMatch; } }
        public string Raw
        { get { return this.raw; } }
        public string RawMatch
        { get { return this.rawMatch; } }

        private string ParseSubber(string filename, out string regexMatch)
        {
            string subber = null;
            regexMatch = string.Empty;

            //Match first instance of a [*]
            Match search = Regex.Match(filename, @"(([\(\[])([0-9a-zA-Z\-_\s]+[^\)\]]+)([\]\)]))");
            if (search.Success)
            {
                //make sure it actually has characters
                string result = search.Value;
                search = Regex.Match(result, @"([a-zA-Z]+)");
                if (search.Success)
                {
                    //make sure we are not grabbing the anime resolution by mistake
                    string dontcare;
                    if (ParseResolution(result, out dontcare) == String.Empty)
                    {
                        regexMatch = result;
                        subber = result;
                    }
                }
            }
            return (subber==null) ? String.Empty : subber;
        }

        private string ParseAnime(string filename)
        {
            List<string> foundTags = new List<string>();
            if(!string.IsNullOrEmpty(this.subberMatch))
            {
                foundTags.Add(this.subberMatch);
            }
            if(!string.IsNullOrEmpty(this.resolutionMatch))
            {
                foundTags.Add(this.resolutionMatch);
            }
            if(!string.IsNullOrEmpty(this.rawMatch))
            {
                foundTags.Add(this.rawMatch);
            }
            string[] tags = foundTags.ToArray();

            //remove Subber if any, Resolution if any, Raw if any
            string[] parsedFileName = filename.Split(tags, StringSplitOptions.RemoveEmptyEntries);

            string anime = String.Empty;
            foreach (string part in parsedFileName)
            {
                anime = anime + part;
            }
            anime = RemoveAllBrackets(anime);
            anime = ConvertUnderScores(anime);
            anime = RemoveDuplicatesOf(@"\s", anime);
            anime = RemoveDuplicatesOf(@"-", anime);
            anime = TrimHyphens(anime);
            anime = anime.Trim();
            return anime;
        }

        private string ParseResolution(string filename, out string regexMatch)
        {
            string resolution = null;
            regexMatch = string.Empty;

            //Match any instance of [{Number}p]
            Match search = Regex.Match(filename, @"\[([0-9]{3,4})p\]", RegexOptions.RightToLeft);
            if (search.Success)
            {
                regexMatch = search.Value;
                resolution = search.Value;
            }
            else
            {
                //Try to match just {Number}p{non letter} , non letter because some files may be named with a number and then a title starting with p
                search = Regex.Match(filename, @"([0-9]{3,4})p([^a-zA-Z])", RegexOptions.RightToLeft);
                if (search.Success)
                {
                    regexMatch = search.Value.Substring(0,search.Value.Length-1);
                    resolution = String.Format("{0}{1}{2}", "[", search.Value.Substring(0,search.Value.Length-1), "]");
                }
                else
                {
                    //Try to match last part of ({Number}x{Number})
                    search = Regex.Match(filename, @"(([^a-zA-Z]\(?)([0-9]{3,4})(\s?)x(\s?[0-9]{3,4})([^a-zA-Z]\)?))", RegexOptions.RightToLeft);
                    if (search.Success)
                    {
                        regexMatch = search.Value;
                        int startIndex = regexMatch.IndexOf('x') + 1;
                        resolution = search.Value.Substring(startIndex).Trim();
                    }
                }
            }
            return (resolution == null) ? String.Empty : resolution;
        }

        private string ParseRaw(string filename, out string regexMatch)
        {
            string raw = null;
            regexMatch = string.Empty;

            Match search = Regex.Match(filename, @"(([\(\[])([r]{1}[a]{1}[w]{1})([\]\)]))", RegexOptions.IgnoreCase);
            if (search.Success)
            {
                regexMatch = search.Value;
                raw = search.Value.Substring(1, search.Value.Length - 2).ToUpper();
            }
            return (raw == null) ? String.Empty : raw;
        }

        public string RelabelFile(RelabelFormat relabelFormat, bool subcheck, bool rescheck, bool rawcheck, out bool probableError)
        {
            string newFileName = string.Empty;
            probableError = false;
            if (relabelFormat.ToIndex() == -1)
            {
                return newFileName;
            }
            else
            {
                //put in the Anime
                newFileName = relabelFormat.ToString().Replace("Anime - Episode", this.anime);
                //put in the Resolution if checked in options
                if(rescheck)
                    newFileName = newFileName.Replace("[Resolution]", this.resolution);
                else
                    newFileName = newFileName.Replace("[Resolution]", string.Empty);
                //put in the Subber if checked in options
                if(subcheck)
                    newFileName = newFileName.Replace("[Subber]", this.subber);
                else
                    newFileName = newFileName.Replace("[Subber]", string.Empty);
                //put in the Raw status if checked in options
                if(rawcheck)
                    newFileName = newFileName.Replace("(raw)", this.raw);
                else
                    newFileName = newFileName.Replace("(raw)", string.Empty);
                newFileName = TrimHyphens(newFileName);
                newFileName = newFileName.Trim();
                if (this.subber == string.Empty &&
                    this.resolution == string.Empty &&
                    this.raw == string.Empty)
                {
                    probableError = true;
                }
                return newFileName;
            }
        }

        #region Helper Methods

        private string RemoveAllBrackets(string parsedString)
        {
            string concatString = string.Empty;
            MatchCollection matches = Regex.Matches(parsedString, @"(([\[\(])(.*)([\]\)]))", RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                var matchedBrackets = matches.OfType<Match>().Select(m => m.Groups[0].Value).ToArray();

                string[] partsString = parsedString.Split(matchedBrackets, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in partsString)
                {
                    concatString = concatString + part;
                }
                return concatString;
            }
            else
            {
                return parsedString;
            }
        }

        private string ConvertUnderScores(string parsedString)
        {
            if (!string.IsNullOrEmpty(parsedString))
                return parsedString.Replace('_',' ');
            else
                return string.Empty;
        }

        private string TrimHyphens(string parsedString)
        {
            if (!string.IsNullOrEmpty(parsedString))
            {
                if (parsedString.IndexOf(" - ") == 0)
                    parsedString = parsedString.Substring(3);
                if (parsedString.IndexOf("- ") == 0)
                    parsedString = parsedString.Substring(2);
                if (parsedString.LastIndexOf(" - ") == parsedString.Length - 4)
                    parsedString = parsedString.Substring(0, parsedString.Length - 4);
                if (parsedString.LastIndexOf(" -") == parsedString.Length - 3)
                    parsedString = parsedString.Substring(0, parsedString.Length - 3);
                return parsedString;
            }
            else
            {
                return string.Empty;
            }
        }

        private string RemoveDuplicatesOf(string regexCharacter, string parsedString)
        {
            MatchCollection matches = Regex.Matches(parsedString, @"("+regexCharacter+"{2,})", RegexOptions.Singleline);
            if (matches.Count > 0)
            {
                var matchedDuplicates = matches.OfType<Match>().Select(m => m.Groups[0].Value).ToArray();

                foreach (string match in matchedDuplicates)
                {
                    parsedString = parsedString.Replace(match, match.Substring(0, 1));
                }
                return parsedString;
            }
            else
            {
                return parsedString;
            }
        }

        #endregion
    }
}
