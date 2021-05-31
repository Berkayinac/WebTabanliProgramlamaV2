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
using System.Text;
using System.Linq;

namespace MorningCoffee.Business.Concrete
{
    public class CoffeeManager : ICoffeeService
    {
        ICoffeeDal _coffeeDal;

        public CoffeeManager(ICoffeeDal coffeeDal)
        {
            _coffeeDal = coffeeDal;
        }

        [SecuredOperation("coffee.add,admin,user")]
        [ValidationAspect(typeof(CoffeeValidator))]
        [CacheRemoveAspect("ICoffeeService.Get")]
        public IResult Add(Coffee coffee)
        {
            BusinessRules.Run(CheckIfCoffeeNameExists(coffee.Name),CheckIfCoffeeCountOfHotCoffeeCorrect(coffee.HotCoffeeId));

            _coffeeDal.Add(coffee);
            return new SuccessResult(Messages.CoffeeAdded);
        }

        [SecuredOperation("coffee.delete,admin,user")]
        [CacheRemoveAspect("ICoffeeService.Get")]
        public IResult Delete(Coffee coffee)
        {
            _coffeeDal.Delete(coffee);
            return new SuccessResult(Messages.CoffeeDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Coffee>> GetAll()
        {
            return new SuccessDataResult<List<Coffee>>(_coffeeDal.GetAll(),Messages.CoffeeListed);
        }

        [CacheAspect]
        public IDataResult<List<Coffee>> GetAllByHotCoffeeId(int hotCoffeeId)
        {
            return new SuccessDataResult<List<Coffee>>(_coffeeDal.GetAll(c=>c.HotCoffeeId == hotCoffeeId),Messages.CoffeeListed);
        }

        [CacheAspect]
        public IDataResult<Coffee> GetByName(string name)
        {
            return new SuccessDataResult<Coffee>(_coffeeDal.Get(c=>c.Name == name),Messages.CoffeeBrought);
        }

        [SecuredOperation("coffee.update,admin,user")]
        [ValidationAspect(typeof(CoffeeValidator))]
        [CacheRemoveAspect("ICoffeeService.Get")]
        public IResult Update(Coffee coffee)
        {
            _coffeeDal.Update(coffee);
            return new SuccessResult(Messages.CoffeeUpdated);
        }

        private IResult CheckIfCoffeeNameExists(string coffeeName)
        {
            var result = _coffeeDal.GetAll(c => c.Name == coffeeName).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CoffeeNameAlreadyExists);
        }

        private IResult CheckIfCoffeeCountOfHotCoffeeCorrect(int hotCoffeeId)
        {
            var result = _coffeeDal.GetAll(c => c.HotCoffeeId == hotCoffeeId).Count;
            if (result >= 13)
            {
                return new ErrorResult(Messages.CoffeeCountOfHotCoffeeError);
            }
            return new SuccessResult();
        }


    }
}
