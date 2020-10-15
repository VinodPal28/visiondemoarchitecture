// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace VisionServicesSample.DependencyResolution
{
    using AutoMapper;
    using AutoMapper.Configuration;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Linq;
    using VisionServices.BL.Interface;
    using VisionServices.BL.Mapping;
    using VisionServices.BL.Services;
    using VisionServices.Data.UnitOfWork;

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            //Get all Profiles
            var profiles = from t in typeof(DefaultRegistry).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(t)
                           select (Profile)Activator.CreateInstance(t);
            //For each Profile, include that profile in the MapperConfiguration
            var config = new MapperConfigurationExpression();
            foreach (var profile1 in profiles)
            {
                config.AddProfile(profile1);
            }

            //Create a mapper that will be used by the DI container
            var mapperConfig = new MapperConfiguration(config);
            var mapper = new Mapper(mapperConfig);

            //Register the DI interfaces with their implementation
            For<Mapper>().Use(mapper);

            //For<IExample>().Use<Example>();
            For<IBookServices>().Use<BookServices>().Ctor<IMapper>().Is(mapper); ;
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<IUserService>().Use<UserServices>();
            For<ITokenServices>().Use<TokenServices>();

           

            

        }
        #endregion
    }
}