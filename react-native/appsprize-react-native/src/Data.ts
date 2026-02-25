

export interface AppsPrizeConfig {
    token: string;
    advertisingId: string;
    userId: string;
    country?: string;
    language?: string;
    gender?: string;
    age?: number;
    uaChannel?: string;
    uaNetwork?: string;
    adPlacement?: string;
    style?: AppsPrizeStyleConfig;
}

export interface AppsPrizeStyleConfig {
    typeface?: string;
    bannerDrawable?: string;
    offersTitleText?: string;
    appsTitleText?: string;
    currencyIcon?: string;
    screenBackgroundColor?: string;
    primaryTextColor?: string;
    onboardingBackgroundColor?: string;
    bottomFloatingBackgroundColor?: string;
    bottomFloatingBorderColor?: string;
    bottomNavigationTextColor?: string;
    bottomNavigationActiveColor?: string;
    itemTitleTextColor?: string;
    itemCategoryTextColor?: string;
    itemImageBorderColor?: string;
    itemBackgroundColor?: string;
    itemBorderColor?: string;
    itemProgressColor?: string;
    itemProgressBackgroundColor?: string;
    appsSelectItemBackgroundColor?: string;
    buttonTextColor?: string;
    itemPurchaseCashbackTextColor?: string;
    itemPurchaseCashbackBackgroundColor?: string;
    itemPurchaseCashbackHighlightColor?: string;
    itemDetailCompleteBorderColor?: string;
    itemLimitedRewardTextColor?: string;
    itemLimitedRewardBorderColor?: string;
    promotionRewardTextColor?: string;
    promotionIconColor?: string;
    inboxTimeTitleColor?: string;
    featuredBackgroundColors?: string[];
    buttonBackgroundColor?: string[];
    itemDetailPurchaseCashbackColor?: string[];
    itemDetailDailyColor?: string[];
    itemLimitedRewardBackgroundColors?: string[];
    promotionGradientColor?: string[];
    secondChanceBackgroundColors?: string[];
}

export interface AppsPrizeOptions {
    type?: "only_time" | "only_task" | "all";
}

export interface RewardLevel {
    level: number;
    points: number;
    currency: string;
}

export interface AppRewards {
    rewards: RewardLevel[];
}

export interface AppsPrizeNotification {
    id: number,
    campaignId: number,
    appName: string,
    description: string,
    hasRead: boolean,
    iconUrl?: string,
    timestamp?: number,
}