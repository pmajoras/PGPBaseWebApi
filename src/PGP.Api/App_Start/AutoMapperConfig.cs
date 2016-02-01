using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PGP.Api.Models.Accounts;
using PGP.Domain.Users;

namespace PGP.Api.App_Start
{
    public static class AutoMapperConfig
    {

        #region Static Properties

        private static IMapper s_mapper;

        /// <summary>
        /// Gets or sets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        /// <exception cref="System.InvalidOperationException">The Mapper is not configured to use.</exception>
        public static IMapper MapperConfig
        {
            get
            {
                if (s_mapper == null)
                {
                    throw new InvalidOperationException("The Mapper is not configured to use.");
                }

                return s_mapper;
            }
            set
            {
                s_mapper = value;
            }
        }

        #endregion

        /// <summary>
        /// Registers the mapping.
        /// </summary>
        public static void RegisterMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>().ReverseMap();
            });

            MapperConfig = config.CreateMapper();
        }
    }
}