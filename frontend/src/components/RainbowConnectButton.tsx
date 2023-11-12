import RainbowKit from "./RainbowKit";
import { ConnectButton } from "@rainbow-me/rainbowkit";

export const RainbowConnectButton = (props: { class: string }) => (
    <RainbowKit className={props.class} children={<ConnectButton />} />
);
