using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
public interface IReportService
    {
        void Report();
    }

    public class ReportingService : IReportService
    {
        public void Report()
        {
            Console.WriteLine("Report");
        }
    }

    public class ReportingServiceWithLogging : IReportService
    {
        private IReportService decorated;

        public ReportingServiceWithLogging(IReportService decorated)
        {
            this.decorated = decorated;
        }

        public void Report()
        {
            Console.WriteLine("Commencing log...");
            decorated.Report();
            Console.WriteLine("Ending log...");
        }
    }
}
