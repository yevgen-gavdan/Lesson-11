using System;
using System.Collections.Generic;

namespace SpecificationPattern
{

    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity candidate);
    }

    public static class SpecificationExtensionMethods
    {
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            return new AndSpecification<TEntity>(spec1, spec2);
        }
        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            return new OrSpecification<TEntity>(spec1, spec2);
        }
        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> spec)
        {
            return new NotSpecification<TEntity>(spec);
        }
    }

    internal class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> m_specification1;
        private readonly ISpecification<TEntity> m_specification2;
        protected ISpecification<TEntity> Spec1 { get { return m_specification1; } }
        protected ISpecification<TEntity> Spec2 { get { return m_specification2; } }

        internal AndSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            if (spec1 == null) throw new ArgumentNullException("spec1");
            if (spec2 == null) throw new ArgumentNullException("spec2");

            m_specification1 = spec1;
            m_specification2 = spec2;
        }
        public bool IsSatisfiedBy(TEntity candidate)
        {
            return Spec1.IsSatisfiedBy(candidate) && Spec2.IsSatisfiedBy(candidate);
        }
    }
    internal class OrSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> m_specification1;
        private readonly ISpecification<TEntity> m_specification2;
        protected ISpecification<TEntity> Spec1 { get { return m_specification1; } }
        protected ISpecification<TEntity> Spec2 { get { return m_specification2; } }

        internal OrSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            if (spec1 == null) throw new ArgumentNullException("spec1");
            if (spec2 == null) throw new ArgumentNullException("spec2");

            m_specification1 = spec1;
            m_specification2 = spec2;
        }
        public bool IsSatisfiedBy(TEntity candidate)
        {
            return Spec1.IsSatisfiedBy(candidate) || Spec2.IsSatisfiedBy(candidate);
        }
    }
    internal class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> m_specification;
        protected ISpecification<TEntity> Spec { get { return m_specification; } }

        internal NotSpecification(ISpecification<TEntity> spec)
        {
            if (spec == null) throw new ArgumentNullException("spec");
            m_specification = spec;
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !m_specification.IsSatisfiedBy(candidate);
        }
    }
}
