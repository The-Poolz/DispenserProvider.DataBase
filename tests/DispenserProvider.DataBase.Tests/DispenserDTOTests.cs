using Xunit;
using FluentAssertions;
using Net.Web3.EthereumWallet;
using DispenserProvider.DataBase.Models;

namespace DispenserProvider.DataBase.Tests;

public class DispenserDTOTests
{
    public class GenerateSourceForId
    {
        [Fact]
        internal void WhenRefundIsNull_ShouldReturnsExpectedString()
        {
            var userAddress = EthereumAddress.ZeroAddress;
            long withdrawChainId = 56;
            long withdrawPoolId = 1;

            var result = DispenserDTO.GenerateSourceForId(userAddress, withdrawChainId, withdrawPoolId);

            result.Should().Be($"{userAddress}-{withdrawChainId}-{withdrawPoolId}");
        }


        [Fact]
        internal void WhenRefundNotNull_ShouldReturnsExpectedString()
        {
            var userAddress = EthereumAddress.ZeroAddress;
            long withdrawChainId = 56;
            long withdrawPoolId = 1;
            long? refundChainId = 97;
            long? refundPoolId = 1;

            var result = DispenserDTO.GenerateSourceForId(userAddress, withdrawChainId, withdrawPoolId, refundChainId, refundPoolId);

            result.Should().Be($"{userAddress}-{withdrawChainId}-{withdrawPoolId}-{refundChainId}-{refundPoolId}");
        }
    }
}