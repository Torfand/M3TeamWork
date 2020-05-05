
using System;
using System.Collections.Generic;
using System.Text;

namespace Vann
{
    public class Water
    {
        private const double CaloriesMeltIcePerGram = 80;
        private const double CaloriesEvaporateWaterPerGram = 600;
        public double Amount;
        public double Temperature;
        public double ProportionState;
        public object State { get; set; }

        public Water(double amount, double temperature, double ? proportion = null)
        {
            Amount = amount;
            Temperature = temperature;
            State = temperature <= 0 ? Wstate.Ice :
                temperature > 100 ? Wstate.Gas : Wstate.Fluid;
            if (temperature != 100 && temperature !=0)return;
            if (proportion == null) throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");
            ProportionState = proportion.Value;
            if (ProportionState == 1)return;

            if (ProportionState == 0) State = temperature == 0 ? Wstate.Fluid : Wstate.Gas;
            else State = temperature == 0 ? Wstate.IceAndFluid : Wstate.FluidAndGas;



        }
        public void AddEnergy(double calories)
        {
            if (Temperature < 0) calories = HeatTo(calories, 0);
            if (Temperature == 0 && State != (object)Wstate.Fluid) calories = DoStateChangeAsMuchAsPossible(calories);
            if (Temperature < 100) calories = HeatTo(calories, 100);
            if (Temperature == 100 && State != (object)Wstate.Gas) calories = DoStateChangeAsMuchAsPossible(calories);
            HeatMax(calories);

        }

        private double DoStateChangeAsMuchAsPossible(in double calories)
        {
            if (calories <= 0) return 0;
            if (Temperature != 0 && Temperature != 100) throw new ApplicationException("Cannot do state change when temperature is not 0 or 100.");
            var isMeltingIce = Temperature == 0;
            var stateChangeEnergyPerGram = isMeltingIce ? CaloriesMeltIcePerGram : CaloriesEvaporateWaterPerGram;
            var caloriesNeeded = stateChangeEnergyPerGram * Amount;
            if (calories >= caloriesNeeded)
            {
                State = isMeltingIce ? Wstate.Fluid : Wstate.Gas;
                return calories - caloriesNeeded;

            }

            ProportionState = 1 - calories / caloriesNeeded;
            State = isMeltingIce ? Wstate.IceAndFluid : Wstate.FluidAndGas;
            return 0;
        }

        private double HeatTo(in double calories, int temprature)
        {
            if (calories < 0) return 0;
            var HeatCalories = (temprature - Temperature) * Amount;
            if (!(calories >= HeatCalories)) return HeatMax(calories);
            Temperature = temprature;
            return calories - HeatCalories;

        }
        private double HeatMax(in double calories)
        {
            if (calories <= 0) return 0;
            var temperatureChange = calories / Amount;
            Temperature += temperatureChange;
            return 0;
        }


    }
    public enum Wstate
    {
        Fluid,
        Ice,
        Gas,
        FluidAndGas,
        IceAndFluid
    }
}




   
