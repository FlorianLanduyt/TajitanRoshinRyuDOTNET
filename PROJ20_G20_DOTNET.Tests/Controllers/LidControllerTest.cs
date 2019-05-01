using Moq;
using PROJ20_G20_DOTNET.Controllers;
using PROJ20_G20_DOTNET.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJ20_G20_DOTNET.Tests.Controllers
{
    public class LidControllerTest
    {
        private LidController _controller;
        private Mock<ILidRepository> _lidRepository;
        

        public LidControllerTest()
        {
            _lidRepository = new Mock<ILidRepository>();
            //_controller = new LidController(_lidRepository.Object) Hoe kan je de Usermanager ne SignInManager mocken ?
            

        }
    }
}
