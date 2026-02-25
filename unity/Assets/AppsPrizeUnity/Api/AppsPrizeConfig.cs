using UnityEngine;


namespace AppsPrizeUnity
{
    public class AppsPrizeConfig
    {
        public readonly string token;
        public readonly string advertisingId;
        public readonly string userId;
        public readonly string country = null;
        public readonly string language = null;
        public readonly string gender = null;
        public readonly int? age = null;
        public readonly string uaChannel = null;
        public readonly string uaNetwork = null;
        public readonly string adPlacement = null;
        public readonly AppsPrizeStyleConfig styleConfig = null;

        public AppsPrizeConfig(
            string token,
            string advertisingId,
            string userId,
            string country = null,
            string language = null,
            string gender = null,
            int? age = null,
            string uaChannel = null,
            string uaNetwork = null,
            string adPlacement = null,
            AppsPrizeStyleConfig styleConfig = null
        ) {
            this.token = token;
            this.advertisingId = advertisingId;
            this.userId = userId;
            this.country = country;
            this.language = language;
            this.gender = gender; 
            this.age = age; 
            this.uaChannel = uaChannel; 
            this.uaNetwork = uaNetwork; 
            this.adPlacement = adPlacement; 
            this.styleConfig = styleConfig;
        }
    }

    public class AppsPrizeStyleConfig
    {
        public readonly string offersTitleText = null;
        public readonly string appsTitleText = null;
        public readonly Color? screenBackgroundColor = null;
        public readonly Color? primaryTextColor = null;
        public readonly Color? onboardingBackgroundColor = null;
        public readonly Color? bottomFloatingBackgroundColor = null;
        public readonly Color? bottomFloatingBorderColor = null;
        public readonly Color? bottomNavigationTextColor = null;
        public readonly Color? bottomNavigationActiveColor = null;
        public readonly Color? itemTitleTextColor = null;
        public readonly Color? itemCategoryTextColor = null;
        public readonly Color? itemImageBorderColor = null;
        public readonly Color? itemBackgroundColor = null;
        public readonly Color? itemBorderColor = null;
        public readonly Color? itemProgressColor = null;
        public readonly Color? itemProgressBackgroundColor = null;
        public readonly Color? appsSelectItemBackgroundColor = null;
        public readonly Color? buttonTextColor = null;
        public readonly Color? itemPurchaseCashbackTextColor = null;
        public readonly Color? itemPurchaseCashbackBackgroundColor = null;
        public readonly Color? itemPurchaseCashbackHighlightColor = null;
        public readonly Color? itemDetailCompleteBorderColor = null;
        public readonly Color? itemLimitedRewardTextColor = null;
        public readonly Color? itemLimitedRewardBorderColor = null;
        public readonly Color? promotionRewardTextColor = null;
        public readonly Color? promotionIconColor = null;
        public readonly Color? inboxTimeTitleColor = null;
        public readonly Color[] featuredBackgroundColors = null;
        public readonly Color[] buttonBackgroundColor = null;
        public readonly Color[] itemDetailPurchaseCashbackColor = null;
        public readonly Color[] itemDetailDailyColor = null;
        public readonly Color[] itemLimitedRewardBackgroundColors = null;
        public readonly Color[] promotionGradientColor = null;
        public readonly Color[] secondChanceBackgroundColors = null;

        public AppsPrizeStyleConfig(
            string offersTitleText = null,
            string appsTitleText = null,
            Color? screenBackgroundColor = null,
            Color? primaryTextColor = null,
            Color? onboardingBackgroundColor = null,
            Color? bottomFloatingBackgroundColor = null,
            Color? bottomFloatingBorderColor = null,
            Color? bottomNavigationTextColor = null,
            Color? bottomNavigationActiveColor = null,
            Color? itemTitleTextColor = null,
            Color? itemCategoryTextColor = null,
            Color? itemImageBorderColor = null,
            Color? itemBackgroundColor = null,
            Color? itemBorderColor = null,
            Color? itemProgressColor = null,
            Color? itemProgressBackgroundColor = null,
            Color? appsSelectItemBackgroundColor = null,
            Color? buttonTextColor = null,
            Color? itemPurchaseCashbackTextColor = null,
            Color? itemPurchaseCashbackBackgroundColor = null,
            Color? itemPurchaseCashbackHighlightColor = null,
            Color? itemDetailCompleteBorderColor = null,
            Color? itemLimitedRewardTextColor = null,
            Color? itemLimitedRewardBorderColor = null,
            Color? promotionRewardTextColor = null,
            Color? promotionIconColor = null,
            Color? inboxTimeTitleColor = null,
            Color[] featuredBackgroundColors = null,
            Color[] buttonBackgroundColor = null,
            Color[] itemDetailPurchaseCashbackColor = null,
            Color[] itemDetailDailyColor = null,
            Color[] itemLimitedRewardBackgroundColors = null,
            Color[] promotionGradientColor = null,
            Color[] secondChanceBackgroundColors = null
        ) {
            this.offersTitleText = offersTitleText;
            this.appsTitleText = appsTitleText;
            this.screenBackgroundColor = screenBackgroundColor;
            this.primaryTextColor = primaryTextColor;
            this.onboardingBackgroundColor = onboardingBackgroundColor;
            this.bottomFloatingBackgroundColor = bottomFloatingBackgroundColor;
            this.bottomFloatingBorderColor = bottomFloatingBorderColor;
            this.bottomNavigationTextColor = bottomNavigationTextColor;
            this.bottomNavigationActiveColor = bottomNavigationActiveColor;
            this.itemTitleTextColor = itemTitleTextColor;
            this.itemCategoryTextColor = itemCategoryTextColor;
            this.itemImageBorderColor = itemImageBorderColor;
            this.itemBackgroundColor = itemBackgroundColor;
            this.itemBorderColor = itemBorderColor;
            this.itemProgressColor = itemProgressColor;
            this.itemProgressBackgroundColor = itemProgressBackgroundColor;
            this.appsSelectItemBackgroundColor = appsSelectItemBackgroundColor;
            this.buttonTextColor = buttonTextColor;
            this.itemPurchaseCashbackTextColor = itemPurchaseCashbackTextColor;
            this.itemPurchaseCashbackBackgroundColor = itemPurchaseCashbackBackgroundColor;
            this.itemPurchaseCashbackHighlightColor = itemPurchaseCashbackHighlightColor;
            this.itemDetailCompleteBorderColor = itemDetailCompleteBorderColor;
            this.itemLimitedRewardTextColor = itemLimitedRewardTextColor;
            this.itemLimitedRewardBorderColor = itemLimitedRewardBorderColor;
            this.promotionRewardTextColor = promotionRewardTextColor;
            this.promotionIconColor = promotionIconColor;
            this.inboxTimeTitleColor = inboxTimeTitleColor;
            this.featuredBackgroundColors = featuredBackgroundColors;
            this.buttonBackgroundColor = buttonBackgroundColor;
            this.itemDetailPurchaseCashbackColor = itemDetailPurchaseCashbackColor;
            this.itemDetailDailyColor = itemDetailDailyColor;
            this.itemLimitedRewardBackgroundColors = itemLimitedRewardBackgroundColors;
            this.promotionGradientColor = promotionGradientColor;
            this.secondChanceBackgroundColors = secondChanceBackgroundColors;
        }
    }

}