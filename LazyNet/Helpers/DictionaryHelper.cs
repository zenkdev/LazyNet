using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DevExpress.Utils;
using DevExpress.Utils.Zip;
using DevExpress.XtraSpellChecker;

namespace Dekart.LazyNet.Helpers
{
    public static class DictionaryHelper
    {
        public static void InitDictionary(SpellChecker spellChecker)
        {
            if (LocalizationHelper.IsJapanese) spellChecker.SpellCheckMode = SpellCheckMode.OnDemand;
            if (spellChecker.Dictionaries.Count > 0) return;
            spellChecker.Dictionaries.Add(GetDefaultDictionary());
        }
        static ISpellCheckerDictionary GetDefaultDictionary()
        {
            var dic = new SpellCheckerISpellDictionary();
            Stream zipFileStream = null;
            InternalZipFileCollection files = null;
            Stream alphabetStream = null, dictionaryStream = null, grammarStream = null;
            try
            {
                zipFileStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Dekart.LazyNet.Resources.Dictionaries.default.zip");
                files = InternalZipArchive.Open(zipFileStream);
                alphabetStream = GetFileStream(files, "RussianAlphabet.txt");
                dictionaryStream = GetFileStream(files, "ru_RU.dic");
                grammarStream = GetFileStream(files, "ru_RU.aff");
                dic.LoadFromStream(dictionaryStream, grammarStream, alphabetStream);
            }
            catch
            {
                // ignored
            }
            finally
            {
                dictionaryStream?.Dispose();
                grammarStream?.Dispose();
                alphabetStream?.Dispose();
                zipFileStream?.Dispose();
                DisposeZipFileStreams(files);
            }
            dic.Culture = new CultureInfo("ru-RU");
            return dic;
        }
        static Stream GetFileStream(InternalZipFileCollection files, string name)
        {
            var stream = files.Find(file => file.FileName.IndexOf(name, StringComparison.Ordinal) >= 0).FileDataStream;
            try
            {
                return CreateMemoryStream(stream);
            }
            finally
            {
                stream.Close();
            }
        }
        static Stream CreateMemoryStream(Stream stream)
        {
            var result = new MemoryStream();
            for (; ; )
            {
                var readedByte = stream.ReadByte();
                if (readedByte < 0)
                    break;
                result.WriteByte((byte)readedByte);
            }
            result.Flush();
            result.Seek(0, SeekOrigin.Begin);
            return result;
        }
        static void DisposeZipFileStreams(IEnumerable<InternalZipFile> files)
        {
            foreach (var file in files)
                file.FileDataStream.Dispose();
        }
    }
}