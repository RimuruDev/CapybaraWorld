using System;
using UniRx;
using Core.Saving;

namespace Core.Player
{
    public class PlayerData : ISaveable, IDisposable
    {
        private const int CoinsReward = 1;
        private const int FoodReward = 1;
        
        private readonly CompositeDisposable _disposable = new();

        public int CoinsAmount { get; private set; } = 0;
        public int FoodAmount { get; private set; } = 0;
        public int LevelNumber { get; private set; } = 1;

        public void Save(SaveData saveData)
        {
            saveData.CoinsAmount = CoinsAmount;
            saveData.FoodAmount = FoodAmount;
            saveData.LevelNumber = LevelNumber;
        }

        public void Load(SaveData saveData)
        {
            CoinsAmount = saveData.CoinsAmount;
            FoodAmount = saveData.FoodAmount;
            LevelNumber = saveData.LevelNumber;
        }

        public void Dispose() => 
            _disposable.Clear();

        public void InitializeEvents(IPlayerEventsHandler playerEvents)
        {
            playerEvents.CoinCollectedCommand
                .Subscribe(_ => AddCoin())
                .AddTo(_disposable);

            playerEvents.FoodCollectedCommand
                .Subscribe(_ => AddFood())
                .AddTo(_disposable);
        }

        public void RemoveCoins(int amount)
        {
            int newAmount = CoinsAmount - amount;
            if (newAmount < 0)
                throw new ArgumentException($"{nameof(PlayerData)}::{nameof(RemoveCoins)}: Not enough coins to remove!");

            CoinsAmount = newAmount;
        }
        
        public void RemoveFood(int amount)
        {
            int newAmount = FoodAmount - amount;
            if (newAmount < 0)
                throw new ArgumentException($"{nameof(PlayerData)}::{nameof(RemoveFood)}: Not enough food to remove - {newAmount}");

            FoodAmount = newAmount;
        }

        public void AddCoin() =>
            CoinsAmount += CoinsReward;

        public void AddFood() =>
            FoodAmount += FoodReward;

        public void IncreaseLevelNumber() => 
            LevelNumber++;
    }
}