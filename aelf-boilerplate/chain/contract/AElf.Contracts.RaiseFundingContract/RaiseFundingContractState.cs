
using AElf.Sdk.CSharp.State;
using AElf.Types;

namespace AElf.Contracts.RaiseFundingContract
{
    public partial class RaiseFundingContractState : ContractState
    {

        public MappedState<long, long> Comic { get; set; }

        public MappedState<long, bool> Status { get; set; }

    }

}