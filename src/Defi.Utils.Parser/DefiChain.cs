﻿using System;
using NBitcoin;
using NBitcoin.DataEncoders;
using NBitcoin.Protocol;

namespace Defi.Utils.Parser
{
    public class DefiChain : NetworkSetBase
    {
        public static DefiChain Instance { get; } = new DefiChain();

        public override string CryptoCode => "DEFI";

        private DefiChain()
        {

        }

        
        protected override NetworkBuilder CreateMainnet()
        {
            var builder = new NetworkBuilder();
            builder.SetConsensus(new Consensus()
                {
                    SubsidyHalvingInterval = 100000,
                    MajorityEnforceBlockUpgrade = 1500,
                    MajorityRejectBlockOutdated = 1900,
                    MajorityWindow = 2000,
                    PowLimit = new Target(
                        new uint256("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                    PowTargetTimespan = TimeSpan.FromSeconds(4 * 60 * 60),
                    PowTargetSpacing = TimeSpan.FromSeconds(60),
                    PowAllowMinDifficultyBlocks = false,
                    CoinbaseMaturity = 30,
                    //  Not set in reference client, assuming false
                    PowNoRetargeting = false,
                    //RuleChangeActivationThreshold = 6048,
                    //MinerConfirmationWindow = 8064,
                    LitecoinWorkCalculation = true,
                    SupportSegwit = false
                })
                .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] {30})
                .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] {22})
                .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] {158})
                .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] {0x02, 0xFA, 0xCA, 0xFD})
                .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] {0x02, 0xFA, 0xC3, 0x98})
                .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("doge"))
                .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("doge"))
                .SetMagic(0xc0c0c0c0)
                .SetPort(22556)
                .SetRPCPort(22555)
                .SetName("doge-main")
                .AddAlias("doge-mainnet")
                .AddAlias("dogecoin-mainnet")
                .AddAlias("dogecoin-main")
                .AddDNSSeeds(new[]
                {
                    new DNSSeedData("dogecoin.com", "seed.dogecoin.com"),
                    new DNSSeedData("multidoge.org", "seed.multidoge.org"),
                    new DNSSeedData("multidoge.org", "seed.multidoge.org"),
                    new DNSSeedData("doger.dogecoin.com", "seed.doger.dogecoin.com")
                })
                .AddSeeds(new NetworkAddress[0])
                .SetGenesis(
                    "010000000000000000000000000000000000000000000000000000000000000000000000696ad20e2dd4365c7459b4a4a5af743d5e92c6da3229e6532cd605f6533f2a5b24a6a152f0ff0f1e678601000101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff1004ffff001d0104084e696e746f6e646fffffffff010058850c020000004341040184710fa689ad5023690c80f3a49c8f13f8d45b8c857fbcbc8bc4a8e4d3eb4b10f4d4604fa08dce601aaf0f470216fe1b51850b4acf21b179c45070ac7b03a9ac00000000");
            return builder;
        }

        protected override NetworkBuilder CreateTestnet()
        {
            var builder = new NetworkBuilder();
            builder.SetName("DefiChainTestnet");
            builder.SetConsensus(new Consensus()
                {
                    SubsidyHalvingInterval = 100000,
                    MajorityEnforceBlockUpgrade = 501,
                    MajorityRejectBlockOutdated = 750,
                    MajorityWindow = 1000,
                    PowLimit = new Target(
                        new uint256("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                    // pre-post-digishield https://github.com/dogecoin/dogecoin/blob/10a5e93a055ab5f239c5447a5fe05283af09e293/src/chainparams.cpp#L45
                    PowTargetTimespan = TimeSpan.FromSeconds(60),
                    PowTargetSpacing = TimeSpan.FromSeconds(60),
                    PowAllowMinDifficultyBlocks = true,
                    CoinbaseMaturity = 240,
                    //  Not set in reference client, assuming false
                    PowNoRetargeting = false,
                    //RuleChangeActivationThreshold = 6048,
                    //MinerConfirmationWindow = 8064,
                    LitecoinWorkCalculation = true,
                    SupportSegwit = false
                })
                .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] {0xf})
                .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] {0x80})
                .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] {0x04, 0x35, 0x87, 0xCF})
                .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] {0x04, 0x35, 0x83, 0x94})
                .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("tf"))
                .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("tf"))
                .SetMagic(0xdcb7c1fc).SetGenesis(
                    "010000000000000000000000000000000000000000000000000000000000000000000000696ad20e2dd4365c7459b4a4a5af743d5e92c6da3229e6532cd605f6533f2a5b24a6a152f0ff0f1e678601000101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff1004ffff001d0104084e696e746f6e646fffffffff010058850c020000004341040184710fa689ad5023690c80f3a49c8f13f8d45b8c857fbcbc8bc4a8e4d3eb4b10f4d4604fa08dce601aaf0f470216fe1b51850b4acf21b179c45070ac7b03a9ac00000000");
            

            return builder;
        }

        protected override NetworkBuilder CreateRegtest()
        {
            var builder = new NetworkBuilder();
            builder.SetConsensus(new Consensus()
                {
                    SubsidyHalvingInterval = 150,
                    MajorityEnforceBlockUpgrade = 750,
                    MajorityRejectBlockOutdated = 950,
                    MajorityWindow = 1000,
                    PowLimit = new Target(
                        new uint256("00000fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                    PowTargetTimespan = TimeSpan.FromSeconds(4 * 60 * 60),
                    PowTargetSpacing = TimeSpan.FromSeconds(60),
                    PowAllowMinDifficultyBlocks = false,
                    CoinbaseMaturity = 60,
                    //  Not set in reference client, assuming false
                    PowNoRetargeting = false,
                    //RuleChangeActivationThreshold = 6048,
                    //MinerConfirmationWindow = 8064,
                    LitecoinWorkCalculation = true,
                    SupportSegwit = false
                })
                .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] {113})
                .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] {196})
                .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] {241})
                .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] {0x04, 0x35, 0x87, 0xCF})
                .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] {0x04, 0x35, 0x83, 0x94})
                .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("tdoge"))
                .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("tdoge"))
                .SetMagic(0xdab5bffa)
                .SetPort(18444)
                .SetRPCPort(44555) // by default this is assigned dynamically, adding port I got for testing
                .SetName("doge-reg")
                .AddAlias("doge-regtest")
                .AddAlias("dogecoin-regtest")
                .AddAlias("dogecoin-reg")
                .AddDNSSeeds(new DNSSeedData[0])
                .AddSeeds(new NetworkAddress[0])
                .SetGenesis(
                    "010000000000000000000000000000000000000000000000000000000000000000000000696ad20e2dd4365c7459b4a4a5af743d5e92c6da3229e6532cd605f6533f2a5bdae5494dffff7f20020000000101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff1004ffff001d0104084e696e746f6e646fffffffff010058850c020000004341040184710fa689ad5023690c80f3a49c8f13f8d45b8c857fbcbc8bc4a8e4d3eb4b10f4d4604fa08dce601aaf0f470216fe1b51850b4acf21b179c45070ac7b03a9ac00000000");
            return builder;
        }

        protected override void PostInit()
        {
            RegisterDefaultCookiePath("DEFI");
        }

    }
}
