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
    public class FrappuccinoManager : IFrappuccinoService
    {
        IFrappuccinoDal _frappuccinoDal;

        public FrappuccinoManager(IFrappuccinoDal frappuccinoDal)
        {
            _frappuccinoDal = frappuccinoDal;
        }

        [SecuredOperation("frappuccino.add,admin,user")]
        [ValidationAspect(typeof(FrappuccinoValidator))]
        [CacheRemoveAspect("IFrappuccinoService.Get")]
        public IResult Add(Frappuccino frappuccino)
        {
            BusinessRules.Run(CheckIfFrappuccinoCountOfFrappuccinoBlendedBeverageCorrect(frappuccino.FrappuccinoBlendedBeverageId),
                CheckIfFrappuccinoNameExists(frappuccino.Name));

            _frappuccinoDal.Add(frappuccino);
            return new SuccessResult(Messages.FrappuccinoAdded);
        }

        [SecuredOperation("frappuccino.delete,admin,user")]
        [CacheRemoveAspect("IFrappuccinoService.Get")]
        public IResult Delete(Frappuccino frappuccino)
        {
            _frappuccinoDal.Delete(frappuccino);
            return new SuccessResult(Messages.FrappuccinoDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Frappuccino>> GetAll()
        {
            return new SuccessDataResult<List<Frappuccino>>(_frappuccinoDal.GetAll(), Messages.FrappuccinoListed);
        }

        [CacheAspect]
        public IDataResult<List<Frappuccino>> GetAllByFrappuccinoBlendedBeverageId(int frappuccinoBlendedBeverageId)
        {
            return new SuccessDataResult<List<Frappuccino>>(_frappuccinoDal.GetAll(f=>f.FrappuccinoBlendedBeverageId == frappuccinoBlendedBeverageId), Messages.FrappuccinoListed);
        }

        [CacheAspect]
        public IDataResult<Frappuccino> GetByName(string name)
        {
            return new SuccessDataResult<Frappuccino>(_frappuccinoDal.Get(f => f.Name == name), Messages.FrappuccinoBrought);
        }


        [SecuredOperation("frappuccino.update,admin,user")]
        [CacheRemoveAspect("IFrappuccinoService.Get")]
        public IResult Update(Frappuccino frappuccino)
        {
            _frappuccinoDal.Update(frappuccino);
            return new SuccessResult(Messages.FrappuccinoUpdated);
        }

        private IResult CheckIfFrappuccinoNameExists(string frappuccinoName)
        {
            var result = _frappuccinoDal.GetAll(f => f.Name == frappuccinoName).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.FrappuccinoNameAlreadyExists);
        }

        private IResult CheckIfFrappuccinoCountOfFrappuccinoBlendedBeverageCorrect(int frappuccinoBlendedBeverageId)
        {
            var result = _frappuccinoDal.GetAll(f => f.FrappuccinoBlendedBeverageId == frappuccinoBlendedBeverageId).Count;
            if (result >= 11)
            {
                return new ErrorResult(Messages.FrappuccinoCountFrappuccinoBlendedBeverageOfError);
            }
            return new SuccessResult();
        }
    }
}
