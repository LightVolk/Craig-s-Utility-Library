﻿/*
Copyright (c) 2011 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.IoC.Providers.Scope;
using Utilities.IoC.Providers.Interfaces;
using Utilities.IoC.Mappings;
using Utilities.IoC.Providers.Implementations;
#endregion

namespace Utilities.IoC.Providers.DefaultProviders
{
    /// <summary>
    /// Standard provider
    /// </summary>
    public class Standard : IProvider
    {
        public IImplementation CreateImplementation(Type ImplementationType, MappingManager MappingManager)
        {
            return new Implementations.Standard(ImplementationType, MappingManager);
        }


        public BaseScope ProviderScope
        {
            get { return new StandardScope(); }
        }

        public IImplementation CreateImplementation(IImplementation Implementation, MappingManager MappingManager)
        {
            return CreateImplementation(Implementation.ReturnType, MappingManager);
        }

        public IImplementation CreateImplementation<ImplementationType>(Func<ImplementationType> Implementation)
        {
            return new Delegate<ImplementationType>(Implementation);
        }
    }
}