using MorningCoffee.Business.Abstract;
using MorningCoffee.Business.BusinessAspects.Autofac;
using MorningCoffee.Business.Constants;
using MorningCoffee.Business.ValidationRules.FluentValidation;
using MorningCoffee.Core.Aspects.Autofac.Caching;
using MorningCoffee.Core.Aspects.Autofac.Validation;
using MorningCoffee.Core.Utilities.Business;
using MorningCoffee.Core.Utilities.Results;
using MorningCoffee.DataAccess.Abstract;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorningCoffee.Business.Concrete
{
    public class TeaManager : ITeaService
    {
        ITeaDal _teaDal;

        public TeaManager(ITeaDal teaDal)
        {
            _teaDal = teaDal;
        }

        [SecuredOperation("frappuccino.add,admin,user")]
        [ValidationAspect(typeof(TeaValidator))]
        [CacheRemoveAspect("ITeaService.Get")]
        public IResult Add(Tea tea)
        {
            BusinessRules.Run(CheckIfTeaNameExists(tea.Name), CheckIfTeaCountOfIcedTeaCorrect(tea.IcedTeaId));

            _teaDal.Add(tea);
            return new SuccessResult(Messages.TeaAdded);
        }

        [SecuredOperation("frappuccino.delete,admin,user")]
        [CacheRemoveAspect("ITeaService.Get")]
        public IResult Delete(Tea tea)
        {
            _teaDal.Delete(tea);
            return new SuccessResult(Messages.TeaDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Tea>> GetAll()
        {
            return new SuccessDataResult<List<Tea>>(_teaDal.GetAll(), Messages.TeaListed);
        }

        [CacheAspect]
        public IDataResult<List<Tea>> GetAllByIcedTeaId(int icedTeaId)
        {
            return new SuccessDataResult<List<Tea>>(_teaDal.GetAll(t=>t.IcedTeaId == icedTeaId),Messages.TeaListed);
        }

        [CacheAspect]
        public IDataResult<Tea> GetByName(string name)
        {
            return new SuccessDataResult<Tea>(_teaDal.Get(t => t.Name == name), Messages.TeaBrought);
        }

        [SecuredOperation("frappuccino.update,admin,user")]
        [ValidationAspect(typeof(TeaValidator))]
        [CacheRemoveAspect("ITeaService.Get")]
        public IResult Update(Tea tea)
        {
            _teaDal.Update(tea);
            return new SuccessResult(Messages.TeaUpdated);
        }

        private IResult CheckIfTeaNameExists(string teaName)
        {
            var result = _teaDal.GetAll(t => t.Name == teaName).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.TeaNameAlreadyExists);
        }

        private IResult CheckIfTeaCountOfIcedTeaCorrect(int icedTeaId)
        {
            var result = _teaDal.GetAll(t => t.IcedTeaId == icedTeaId).Count;
            if (result >= 12)
            {
                return new ErrorResult(Messages.TeaCountOfIcedTeaError);
            }
            return new SuccessResult();
        }
    }
}
