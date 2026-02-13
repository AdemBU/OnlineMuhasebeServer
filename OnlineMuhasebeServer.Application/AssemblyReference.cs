using System.Reflection;

namespace OnlineMuhasebeServer.Application
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
    }
}

//Bu sınıf projenin "kimlik kartı" gibidir. Projeyi başka bir kütüphaneye (MediatR, AutoMapper, FluentValidation vb.) tanıtmak için kullanılan temiz ve merkezi bir kapıdır.