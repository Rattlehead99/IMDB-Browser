using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using IMDB_Browser.Models;

namespace IMDB_Browser;

public class RecordLoader : IDisposable
{
    private readonly StreamReader _reader;
    private readonly CsvReader _csv;

    public RecordLoader(string path)
    {
        _reader = new StreamReader(path);
        _csv = new CsvReader(_reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            IgnoreReferences = true,
            PrepareHeaderForMatch = (x) => x.Header[..0].ToLower() + x.Header[1..].ToLower(),
            Delimiter = "\t",
            Mode = CsvMode.NoEscape
        });

        //csv.Context.RegisterClassMap<FooMap>();
        _csv.Context.TypeConverterOptionsCache.GetOptions<int?>().NullValues.Add("\\N");
        _csv.Context.TypeConverterOptionsCache.GetOptions<string?>().NullValues.Add("\\N");
    }
    public IEnumerable<T> LoadRecords<T>()
    {
        

        IEnumerable<T> records = _csv.GetRecords<T>();

        return records;
    }

    public void Dispose()
    {
        _reader.Dispose();
        _csv.Dispose();
    }
}