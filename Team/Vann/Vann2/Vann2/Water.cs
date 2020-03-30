using System;
using System.Collections.Generic;
using System.Text;

namespace Vann2
{
    public class Water
    {
        private const double CaloriesMeltIcePerGram = 80;
        private const double CaloriesEvaporateWaterPerGram = 600;
        public double Temperature;
        public double Amount;
        public object State { get; set; }
        public double ProportionFirstState;

        public Water(double temperature, double amount, double? proportion = null)
        {

            Temperature = temperature;
            Amount = amount;
            State = temperature <= 0 ? WaterState.Ice :
                temperature > 100 ? WaterState.Gas : WaterState.Fluid;
            if (temperature != 100 && temperature != 0) return;
            if (proportion == null)
                throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");

            ProportionFirstState = proportion.Value;
            if (ProportionFirstState == 1) return;
            if (ProportionFirstState == 0) State = temperature == 0 ? WaterState.Fluid : WaterState.Gas;
            else State = temperature == 0 ? WaterState.IceAndFluid : WaterState.FluidAndGas;

        }
        public void AddEnergy(double calories)
        {
            if (Temperature < 0) calories = heatTo(calories, 0);
            if (Temperature == 0 && State != (object) WaterState.Fluid) calories = StateChangeWhilePossible(calories);
            if (Temperature < 100) calories = heatTo(calories, 100);
            if (Temperature == 100 && State != (object) WaterState.Gas)calories = StateChangeWhilePossible(calories);
            heatMax(calories);

        }

        private double heatMax(in double calories)
        {
            if (calories <= 0) return 0;
            var temperatureChange = calories / Amount;
            Temperature += temperatureChange;
            return 0;
        }

        private double StateChangeWhilePossible(in double calories)
        {
            if (calories <= 0) return 0;
            if (Temperature != 0 && Temperature != 100) throw new ApplicationException("Cannot do state change when temperature is not 0 or 100.");
            var isMeltingIce = Temperature == 0;
            var stateChangeEnergyPerGram = isMeltingIce ? CaloriesMeltIcePerGram : CaloriesEvaporateWaterPerGram;
            var caloriesNeeded = stateChangeEnergyPerGram * Amount;
            if (calories >= caloriesNeeded)
            {
                State = isMeltingIce ? WaterState.Fluid : WaterState.Gas;
                return calories - caloriesNeeded;

            }

            ProportionFirstState = 1 - calories / caloriesNeeded;
            State = isMeltingIce ? WaterState.IceAndFluid : WaterState.FluidAndGas;
            return 0;
        }

        private double heatTo(in double calories, int temperature)
        {
            if (calories < 0) return 0;
            var HeatCalories = (temperature - Temperature) * Amount;
            if (!(calories >= HeatCalories)) return heatMax(calories);
            Temperature = temperature;
            return calories - HeatCalories;



        }
    }
   

    public enum WaterState
    {
        Fluid,
        Ice,
        Gas,
        IceAndFluid,
        FluidAndGas
    }
}
