using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCIoc.Models
{
    public interface IProteinRepository
    {
        ProteinData GetData(DateTime dateTime);
        void SetTotal(DateTime dateTime, int value);
        void SetGoal(DateTime dateTime, int value);
    }

    public class ProteinRepository : IProteinRepository
    {
        private readonly string _dataSource;

        public ProteinRepository(string dataSource)
        {
            _dataSource = dataSource;
        }

        private static ProteinData data = new ProteinData();
        public ProteinData GetData(DateTime dateTime)
        {
            return data;
        }

        public void SetTotal(DateTime dateTime, int value)
        {
            data.Total = value;
        }

        public void SetGoal(DateTime dateTime, int value)
        {
            data.Goal = value;
        }
    }
}
