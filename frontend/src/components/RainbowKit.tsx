import "@rainbow-me/rainbowkit/styles.css";

import { getDefaultWallets, RainbowKitProvider } from "@rainbow-me/rainbowkit";
import { configureChains, createConfig, WagmiConfig } from "wagmi";
import { mainnet, polygon, optimism, arbitrum, base, zora } from "wagmi/chains";
import { alchemyProvider } from "wagmi/providers/alchemy";
import { publicProvider } from "wagmi/providers/public";
import "./Polyfill";

export default function RainbowKit({
    children,
    className,
}: {
    children: JSX.Element;
    className: string;
}) {
    const { chains, publicClient } = configureChains(
        [mainnet, polygon, optimism, arbitrum, base, zora],
        [
            alchemyProvider({ apiKey: import.meta.env.PUBLIC_ALCHEMY_API_KEY }),
            publicProvider(),
        ]
    );

    const { connectors } = getDefaultWallets({
        appName: "POAP Central",
        projectId: import.meta.env.PUBLIC_WALLETCONNECT_PROJECT_ID,
        chains,
    });

    const wagmiConfig = createConfig({
        autoConnect: true,
        connectors,
        publicClient,
    });

    return (
        <WagmiConfig config={wagmiConfig}>
            <RainbowKitProvider chains={chains}>
                <div className={className}>{children}</div>
            </RainbowKitProvider>
        </WagmiConfig>
    );
}
