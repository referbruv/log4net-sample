using System;
using System.Collections.Generic;

namespace TestApi.Providers
{
    public interface IReaderStore
    {
        IEnumerable<Reader> Readers { get; }
    }

    public class ReaderStore : IReaderStore
    {
        private ILoggerManager logger;

        public ReaderStore(ILoggerManager logger)
        {
            this.logger = logger;
            this.logger.LogInformation("On the ReaderStore constructor");
        }

        public IEnumerable<Reader> Readers => this.Seed();

        private IEnumerable<Reader> Seed()
        {
            int id = 0;
            for (int i = 1; i <= 10; i++)
            {
                id = 1000 + i;
                yield return new Reader() {
                    Id = id,
                    Name = $"Reader#{id}",
                    EmailAddress = $"reader.{id}@abc.com"
                };
            }
        }
    }

    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}