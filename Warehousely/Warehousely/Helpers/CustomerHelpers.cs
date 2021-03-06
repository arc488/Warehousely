﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;
using Warehousely.Models;
using Warehousely.ViewModels.CustomerViewModels;

namespace Warehousely.Controllers.Helpers
{
    public class CustomerHelpers
    {
        public CustomerViewModel GenerateCustomerViewModel(IMapper mapper,
                                                           ICustomerRepository customerRepository,
                                                           int id)
        {
            var customer = customerRepository.GetById(id);
            var viewModel = mapper.Map<CustomerViewModel>(customer);
            mapper.Map(customer.Address, viewModel);

            return viewModel;
        }


    }
}
