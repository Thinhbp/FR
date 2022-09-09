using System.Collections.Generic;
using System.Linq;
using AElf.CSharp.Core;
using AElf.Sdk.CSharp;
using AElf.Types;
using Google.Protobuf.WellKnownTypes;


namespace AElf.Contracts.RaiseFundingContract
{
    /// <summary>
    /// The C# implementation of the contract defined in raise_funding_contract.proto that is located in the "protobuf"
    /// folder.
    /// Notice that it inherits from the protobuf generated code. 
    /// </summary>
    public class RaiseFundingContract : RaiseFundingContractContainer.RaiseFundingContractBase
    {
        /// <summary>
        /// The implementation of the Hello method. It takes no parameters and returns on of the custom data types
        /// defined in the protobuf definition file.
        /// </summary>
        /// <param name="input">Empty message (from Protobuf)</param>
        /// <returns>a HelloReturn</returns>
        public override Int64Value DepositMoney(Funding fundingInfo)
        {
            Assert(fundingInfo.ValueFunding > 0, "Invalid value");
            Context.LogDebug(() => $"Raise with value {fundingInfo.ValueFunding}");
            if (string.IsNullOrEmpty(State.Status[fundingInfo.IdComic].ToString()))
            {
                State.Comic[fundingInfo.IdComic] = 0;
                State.Status[fundingInfo.IdComic] = true;

            }

            State.Comic[fundingInfo.IdComic] = State.Comic[fundingInfo.IdComic] + fundingInfo.ValueFunding;

            return new Int64Value { Value = fundingInfo.ValueFunding };
        }

        public Int64Value Checkbalance(Identifier input)
        {
            return new Int64Value { Value = State.Comic[input.Id] };

        }
    }
}