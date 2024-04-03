using AutoMapper;
using MediatR;
using Senac.eShop.Application.Interfaces;
using Senac.eShop.Application.ViewModel;
using Senac.eShop.Domain.Entities;
using Senac.eShop.Domain.Interfaces;
using Senac.eShop.Domain.Shared.Transaction;
using System.Linq.Expressions;

namespace Senac.eShop.Application.Services
{
    public class ClientAppService : BaseService, IClientAppService
    {
        protected readonly IClientRepository _repository;
        protected readonly IAddressAppService _addressAppService;
        protected readonly IMapper _mapper;

        public ClientAppService(IClientRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus,
            IAddressAppService addressAppService) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
            _addressAppService = addressAppService;
        }

        public ClientViewModel Add(ClientViewModel viewModel)
        {
            viewModel.AddressClient = _addressAppService.GetById(viewModel.AddressId);

            Client domain = _mapper.Map<Client>(viewModel);
            domain = _repository.Add(domain);
            Commit();

            ClientViewModel viewModelReturn = _mapper.Map<ClientViewModel>(domain);
            return viewModelReturn;
        }

        public ClientViewModel GetById(Guid id)
        {
            Client client = _repository.GetById(id);
            ClientViewModel clientViewModel = _mapper.Map<ClientViewModel>(client);
            return clientViewModel;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Client, bool>> expression)
        {
            _repository.Remove(expression);
            Commit();
        }

        public IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> expression)
        {
            var clients = _repository.Search(expression);
            var clientsViewModel = _mapper.Map<IEnumerable<ClientViewModel>>(clients);
            return clientsViewModel;
        }

        public IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> expression,
            int pageNumber,
            int pageSize)
        {
            var clients = _repository.Search(expression, pageNumber, pageSize);
            var clientsViewModel = _mapper.Map<IEnumerable<ClientViewModel>>(clients);
            return clientsViewModel;
        }


        public ClientViewModel Update(ClientViewModel viewModel)
        {
            var client = _mapper.Map<Client>(viewModel);
            client = _repository.Update(client);
            Commit();

            var clientViewModel = _mapper.Map<ClientViewModel>(client);
            return clientViewModel;
        }
    }

}
