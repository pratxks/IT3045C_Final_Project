using Final_Project.Data;
using Final_Project.Interfaces;
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services
{
    public class FoodAccessService : IFoodAccessInterface
    {
        private FoodAccessContext _foodAccessContext;

        public FoodAccessService(FoodAccessContext foodAccessContext)
        {
            _foodAccessContext = foodAccessContext;
        }

        public List<Food> GetAllFoodRecords()
        {
            return _foodAccessContext.FoodRecords.ToList();
        }

        private Food FoodByID(int id)
        {
            return _foodAccessContext.FoodRecords.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public List<Food> GetFoodRecordByID(int id)
        {
            List<Food> foodList = _foodAccessContext.FoodRecords.ToList();

            Food foodById = FoodByID(id);

            if (foodById == null)
            {
                return foodList.Take(5).ToList();
            }
            else
            {
                return foodList.Where(x => x.Id.Equals(id)).ToList();
            }
        }

        public int? RemoveFoodRecordById(int id)
        {
            var foodRecToDelete = this.FoodByID(id);

            if (foodRecToDelete == null) return null;
            try
            {
                _foodAccessContext.FoodRecords.Remove(foodRecToDelete);
                _foodAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateFoodRecord(Food existingFoodRecord)
        {
            var foodRecordToUpdate = this.FoodByID(existingFoodRecord.Id);

            if (foodRecordToUpdate == null)
                return null;

            foodRecordToUpdate.fullName = existingFoodRecord.fullName;
            foodRecordToUpdate.favoriteBreakfast = existingFoodRecord.favoriteBreakfast;
            foodRecordToUpdate.favoriteLunch = existingFoodRecord.favoriteLunch;
            foodRecordToUpdate.favoriteDinner = existingFoodRecord.favoriteDinner;

            try
            {
                _foodAccessContext.FoodRecords.Update(foodRecordToUpdate);
                _foodAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int? AddFoodRecord(Food newFoodRecord)
        {
            var foodRecordExist = _foodAccessContext.FoodRecords.Where(x => x.fullName.Equals(newFoodRecord.fullName)).FirstOrDefault();
            if (foodRecordExist != null)
            {
                return null;
            }
            try
            {
                _foodAccessContext.FoodRecords.Add(newFoodRecord);
                _foodAccessContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
