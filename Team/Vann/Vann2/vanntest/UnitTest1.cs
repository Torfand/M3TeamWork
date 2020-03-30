using System;
using NUnit.Framework;
using Vann2;
namespace vanntest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test01WaterAt20Degrees()
        {
            var water = new Water(20,50);
            Assert.AreEqual(WaterState.Fluid, water.State);
            Assert.AreEqual(20, water.Temperature);
            Assert.AreEqual(50, water.Amount);
        }
        [Test]
        public void Test02WaterAtMinus20Degrees()
        {
            var water = new Water(-20, 50);
            Assert.AreEqual(WaterState.Ice, water.State);
            Assert.AreEqual(-20, water.Temperature);
        }
        [Test]
        public void Test03WaterAt120Degrees()
        {
            var water = new Water(120, 50);
            Assert.AreEqual(WaterState.Gas, water.State);
            Assert.AreEqual(120, water.Temperature);
        }
        [Test]
        public void testException() { 
        Assert.Throws<ArgumentException>(() => Test04WaterAt100DegreesWithoutProportion());
        }

        public void Test04WaterAt100DegreesWithoutProportion()
        {
            var water = new Water(100, 50);
        }
        [Test]
        public void Test05WaterAt100Degrees()
        {
            var water = new Water(100, 50, 0.3);
            Assert.AreEqual(WaterState.FluidAndGas, water.State);
            Assert.AreEqual(100, water.Temperature);
            Assert.AreEqual(0.3, water.ProportionFirstState);
        }
        [Test]
        public void Test06WaterAt100Degrees()
        {
            var water = new Water(100, 50, 0.3);
            Assert.AreEqual(WaterState.FluidAndGas, water.State);
            Assert.AreEqual(100, water.Temperature);
        }
        [Test]
        public void Test07WaterAt100Degrees()
        {
            var water = new Water(100, 50, 0.3);
            Assert.AreEqual(WaterState.FluidAndGas, water.State);
            Assert.AreEqual(100, water.Temperature);
        }
        [Test]
        
        public void Test08AddEnergy1()
        {
            var water = new Water(10, 4);
            water.AddEnergy(10);
            Assert.AreEqual(12.5, water.Temperature);
        }
        [Test]
        public void Test09AddEnergy2()
        {
            var water = new Water(-10, 4);
            water.AddEnergy(10);
            Assert.AreEqual(-7.5, water.Temperature);
        }

        [Test]
   
        public void Test10AddEnergy3()
        {
            var water = new Water(-10, 4);
            water.AddEnergy(168);
            Assert.AreEqual(0, water.Temperature);
            Assert.AreEqual(WaterState.IceAndFluid, water.State);
            Assert.AreEqual(0.6, water.ProportionFirstState);
        }
        [Test]
        public void Test11AddEnergy4()
        {
            var water = new Water(-10, 4);
            water.AddEnergy(360);
            Assert.AreEqual(0, water.Temperature);
            Assert.AreEqual(WaterState.Fluid, water.State);
        }
        [Test]
        // Tester at overflødig energi etter smelting går til oppvarming med riktig antall grader.
        public void Test12AddEnergy5()
        {
            var water = new Water(-10, 4);
            water.AddEnergy(400);
            Assert.AreEqual(10, water.Temperature);
            Assert.AreEqual(WaterState.Fluid, water.State);
        }

        [Test]
        public void Test13FluidToGasA()
        {
            var water = new Water(70, 10);
            water.AddEnergy(900);
            Assert.AreEqual(100, water.Temperature);
            Assert.AreEqual(WaterState.FluidAndGas, water.State);
            Assert.AreEqual(0.9, water.ProportionFirstState);
        }

        [Test]
        public void Test14FluidToGasB()
        {
            var water = new Water(70, 10);
            water.AddEnergy(6300);
            Assert.AreEqual(100, water.Temperature);
            Assert.AreEqual(WaterState.Gas, water.State);
        }

        [Test]
        public void Test14FluidToGasC()
        {
            var water = new Water(70, 10);
            water.AddEnergy(6400);
            Assert.AreEqual(110, water.Temperature);
            Assert.AreEqual(WaterState.Gas, water.State);
        }
    }
}