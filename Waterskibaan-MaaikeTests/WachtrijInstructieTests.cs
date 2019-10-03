using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Waterskibaan;
using FluentAssertions;

namespace Waterskibaan_MaaikeTests
{
    public class WachtrijInstructieTests
    {

        [Fact]
        public void MaxLengteRij_ShouldBe_OneHundred()
        {
            // Arrange
            var wachtrij = new WachtrijInstructie();

            // Act
            // Assert
            wachtrij.MaxLengteRij.Should().Be(100);
        }

        [Fact]
        public void DefaultWachtrijInstructie_Should_HaveEmptyQueue()
        {
            // Arrange
            var expected = 0;
            var wachtrij = new WachtrijInstructie();

            // Act
            // Assert
            wachtrij.GetAlleSporters().Count.Should().Be(expected);
        }

        [Fact]
        public void SportersNeemPlaatsInRij_Should_AddSporterToQueue()
        {
            // Arrange
            var expected = 1;
            var wachtrij = new WachtrijInstructie();

            // Act
            wachtrij.SporterNeemPlaatsInRij(new Sporter());

            // Assert
            wachtrij.GetAlleSporters().Count.Should().Be(expected);
        }

        [Fact]
        public void GetAlleSporters_Should_ReturnExpectedSporters()
        {
            // Arrange
            var expected = 3;
            var wachtrij = new WachtrijInstructie();

            // Act
            wachtrij.SporterNeemPlaatsInRij(new Sporter());            
            wachtrij.SporterNeemPlaatsInRij(new Sporter());            
            wachtrij.SporterNeemPlaatsInRij(new Sporter());

            // Assert
            wachtrij.GetAlleSporters().Count.Should().Be(expected);
        }

        [Fact]
        public void SportersVerlatenRij_Should_DequeueOneSporter()
        {
            // Arrange
            var expected = 2;
            var wachtrij = new WachtrijInstructie();
            wachtrij.SporterNeemPlaatsInRij(new Sporter());
            wachtrij.SporterNeemPlaatsInRij(new Sporter());
            wachtrij.SporterNeemPlaatsInRij(new Sporter());

            // Act
            wachtrij.SportersVerlatenRij(1);

            // Assert
            wachtrij.GetAlleSporters().Count.Should().Be(expected);
        }

        [Fact]
        public void SportersVerlatenRij_Should_ReturnEmptyListOnEmptyQueue()
        {
            // Arrange
            var expected = 0;
            var wachtrij = new WachtrijInstructie();

            // Act
            wachtrij.SportersVerlatenRij(1);

            // Assert
            wachtrij.GetAlleSporters().Count.Should().Be(0);
        }

        [Fact]
        public void SportersVerlatenRijMoreThanAreQueued_Should_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            var expected = 2;
            var wachtrij = new WachtrijInstructie();
            wachtrij.SporterNeemPlaatsInRij(new Sporter());
            wachtrij.SporterNeemPlaatsInRij(new Sporter());
            wachtrij.SporterNeemPlaatsInRij(new Sporter());

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => wachtrij.SportersVerlatenRij(4));
        }
    }
}
