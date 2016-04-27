using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SpecificationPattern;

namespace Lesson12
{
    class Program
    {
        static void Main(string[] args)
        {
            var InputFile = new List<string>();
            var OutputWhiteList = new List<string>();
            var OutputBlackList = new List<string>();
            var OutputBlackAndWhiteList = new List<string>();
            var WhiteList1 = new List<string>();
            var WhiteList2 = new List<string>();
            var BlackList1 = new List<string>();
            var BlackList2 = new List<string>();

            #region Read all Files
            using ( StreamReader InputReader = new StreamReader("Input.txt"),
                           Whitelist1Reader = new StreamReader("Whitelist1.txt"),
                           Whitelist2Reader = new StreamReader("Whitelist2.txt"),
                           BlackList1Reader = new StreamReader("BlackList1.txt"),
                           BlackList2Reader = new StreamReader("BlackList2.txt") )
            {
                string line;
                while ((line = InputReader.ReadLine()) != null)
	            {
                    InputFile.Add(line);
	            }
                while ((line = Whitelist1Reader.ReadLine()) != null)
	            {
                    WhiteList1.Add(line);
	            }
                while ((line = Whitelist2Reader.ReadLine()) != null)
	            {
                    WhiteList2.Add(line);
	            }
                while ((line = BlackList1Reader.ReadLine()) != null)
	            {
                    BlackList1.Add(line);
	            }
                while ((line = BlackList2Reader.ReadLine()) != null)
	            {
                    BlackList2.Add(line);
	            }
            }
            #endregion

            var IsInWhitelist1 = new WhiteListSpecification<string>(WhiteList1, (list,  candidate) => list.Contains(candidate) );
            var IsInWhitelist2 = new WhiteListSpecification<string>(WhiteList2, (list, candidate) => list.Contains(candidate) );
            var DoesNotExcistInBlackList1 = new BlackListSpecification<string>(BlackList1, (list,  candidate) => !list.Contains(candidate) );
            var DoesNotExcistInBlackList2 = new BlackListSpecification<string>(BlackList2, (list,  candidate) => !list.Contains(candidate) );

            ISpecification<string> WhiteListFilteringRule = IsInWhitelist1.Or(IsInWhitelist2);
            ISpecification<string> BlackListFilteringRule = DoesNotExcistInBlackList1.And(DoesNotExcistInBlackList2);
            ISpecification<string> WhiteAndBlackListFilteringRule = WhiteListFilteringRule.And(BlackListFilteringRule);

            #region Perform Filtering
            foreach (var name in InputFile)
            {
                if (WhiteListFilteringRule.IsSatisfiedBy(name))
                {
                    OutputWhiteList.Add(name);
                }
                if (BlackListFilteringRule.IsSatisfiedBy(name))
                {
                    OutputBlackList.Add(name);
                }
                if (WhiteAndBlackListFilteringRule.IsSatisfiedBy(name))
                {
                    OutputBlackAndWhiteList.Add(name);
                }
            }
            #endregion

            #region SaveResults to File
            using ( StreamWriter WhiteWriter = new StreamWriter("Output_White_List.txt"),
                                 BlackWriter = new StreamWriter("Output_Black_List.txt"),
                                 BlackAndWhiteWriter = new StreamWriter("Output_Black_And_White_List.txt") )
            {
                foreach (var line in OutputWhiteList)
	            {
                    WhiteWriter.WriteLine(line);
	            }
                foreach (var line in OutputBlackList)
                {
                    BlackWriter.WriteLine(line);
                }
                foreach (var line in OutputBlackAndWhiteList)
                {
                    BlackAndWhiteWriter.WriteLine(line);
                }
            }
            #endregion
        }
    }

    public class WhiteListSpecification<TEntity> : ISpecification<TEntity>
    {
        private IEnumerable<TEntity> m_whiteList;
        private Func<IEnumerable<TEntity>, TEntity, bool> m_FiltrationLogic;

        public WhiteListSpecification(IEnumerable<TEntity> FiltrationData, Func<IEnumerable<TEntity>, TEntity, bool> FiltrationLogic)
        {
            m_whiteList = FiltrationData;
            m_FiltrationLogic = FiltrationLogic;
        }
        public bool IsSatisfiedBy(TEntity candidate)
        {
            if (m_FiltrationLogic == null || m_whiteList == null)
            {
                throw new ArgumentNullException("FiltrationLogic or FiltrationData does not exist");
            }
            return m_FiltrationLogic(m_whiteList, candidate);
        }
    }
    public class BlackListSpecification<TEntity> : ISpecification<TEntity>
    {
        private IEnumerable<TEntity> m_blackList;
        private Func<IEnumerable<TEntity>, TEntity, bool> m_FiltrationLogic;

        public BlackListSpecification(IEnumerable<TEntity> FiltrationData, Func<IEnumerable<TEntity>, TEntity, bool> FiltrationLogic)
        {
            m_blackList = FiltrationData;
            m_FiltrationLogic = FiltrationLogic;
        }
        public bool IsSatisfiedBy(TEntity candidate)
        {
            if (m_FiltrationLogic == null || m_blackList == null)
            {
                throw new ArgumentNullException("FiltrationLogic or FiltrationData does not exist");
            }
            return m_FiltrationLogic(m_blackList, candidate);
        }
    }
}
