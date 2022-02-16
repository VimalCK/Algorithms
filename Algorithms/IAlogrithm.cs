namespace Algorithms
{
    internal interface IAlogrithm
    {
        internal interface IAlogrithm
        {
            void Run();
        }

        internal interface IAlgorithm<T>
        {
            void Run(T value);

        }

        internal interface IAlgorithm<T1, T2>
        {
            void Run(T1 value1, T2 value2);
        }
    }
}
