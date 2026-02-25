using UnityEngine;


namespace AppsPrizeUnity.Platforms.Android
{
    internal static class AppsPrizeConfigAndroid
    {
        public static AndroidJavaObject Create(AppsPrizeConfig config)
        {
            AndroidJavaObject configBuilder = new("com.appsamurai.appsprize.config.AppsPrizeConfig$Builder");

            if (!string.IsNullOrEmpty(config.country))
            {
                configBuilder.Call<AndroidJavaObject>("setCountry", config.country);
            }

            if (!string.IsNullOrEmpty(config.language))
            {
                configBuilder.Call<AndroidJavaObject>("setLanguage", config.language);
            }
            
            if (!string.IsNullOrEmpty(config.gender))
            {
                configBuilder.Call<AndroidJavaObject>("setGender", config.gender);
            }

            if (config.age.HasValue)
            {
                configBuilder.Call<AndroidJavaObject>("setAge", AndroidUtil.ToAndroidInt(config.age.Value));
            }

            if (!string.IsNullOrEmpty(config.uaChannel))
            {
                configBuilder.Call<AndroidJavaObject>("setUaChannel", config.uaChannel);
            }

            if (!string.IsNullOrEmpty(config.uaNetwork))
            {
                configBuilder.Call<AndroidJavaObject>("setUaNetwork", config.uaNetwork);
            }

            if (!string.IsNullOrEmpty(config.adPlacement))
            {
                configBuilder.Call<AndroidJavaObject>("setAdPlacement", config.adPlacement);
            }

            if (config.styleConfig != null)
            {
                configBuilder.Call<AndroidJavaObject>("setStyle", CreateStyleConfig(config.styleConfig));
            }

            AndroidJavaObject appsPrizeConfig = configBuilder.Call<AndroidJavaObject>("build", config.token, config.advertisingId, config.userId);
            return appsPrizeConfig;
        }

        static AndroidJavaObject CreateStyleConfig(AppsPrizeStyleConfig styleConfig)
        {
            AndroidJavaObject styleConfigBuilder = new("com.appsamurai.appsprize.config.style.AppsPrizeStyleConfig$Builder");

            if (!string.IsNullOrEmpty(styleConfig.offersTitleText))
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setOffersTitleText", styleConfig.offersTitleText);
            }
            if (!string.IsNullOrEmpty(styleConfig.appsTitleText))
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setAppsTitleText", styleConfig.appsTitleText);
            }
            if (styleConfig.screenBackgroundColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setScreenBackgroundColor", AndroidUtil.ToAndroidColor(styleConfig.screenBackgroundColor.Value));
            }
            if (styleConfig.primaryTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setPrimaryTextColor", AndroidUtil.ToAndroidColor(styleConfig.primaryTextColor.Value));
            }
            if (styleConfig.onboardingBackgroundColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setOnboardingBackgroundColor", AndroidUtil.ToAndroidColor(styleConfig.onboardingBackgroundColor.Value));
            }
            if (styleConfig.bottomFloatingBackgroundColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setBottomFloatingBackgroundColor", AndroidUtil.ToAndroidColor(styleConfig.bottomFloatingBackgroundColor.Value));
            }
            if (styleConfig.bottomFloatingBorderColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setBottomFloatingBorderColor", AndroidUtil.ToAndroidColor(styleConfig.bottomFloatingBorderColor.Value));
            }
            if (styleConfig.bottomNavigationTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setBottomNavigationTextColor", AndroidUtil.ToAndroidColor(styleConfig.bottomNavigationTextColor.Value));
            }
            if (styleConfig.bottomNavigationActiveColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setBottomNavigationActiveColor", AndroidUtil.ToAndroidColor(styleConfig.bottomNavigationActiveColor.Value));
            }
            if (styleConfig.itemTitleTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemTitleTextColor", AndroidUtil.ToAndroidColor(styleConfig.itemTitleTextColor.Value));
            }
            if (styleConfig.itemCategoryTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemCategoryTextColor", AndroidUtil.ToAndroidColor(styleConfig.itemCategoryTextColor.Value));
            }
            if (styleConfig.itemImageBorderColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemImageBorderColor", AndroidUtil.ToAndroidColor(styleConfig.itemImageBorderColor.Value));
            }
            if (styleConfig.itemBackgroundColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemBackgroundColor", AndroidUtil.ToAndroidColor(styleConfig.itemBackgroundColor.Value));
            }
            if (styleConfig.itemBorderColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemBorderColor", AndroidUtil.ToAndroidColor(styleConfig.itemBorderColor.Value));
            }
            if (styleConfig.itemProgressColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemProgressColor", AndroidUtil.ToAndroidColor(styleConfig.itemProgressColor.Value));
            }
            if (styleConfig.itemProgressBackgroundColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemProgressBackgroundColor", AndroidUtil.ToAndroidColor(styleConfig.itemProgressBackgroundColor.Value));
            }
            if (styleConfig.appsSelectItemBackgroundColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setAppsSelectItemBackgroundColor", AndroidUtil.ToAndroidColor(styleConfig.appsSelectItemBackgroundColor.Value));
            }
            if (styleConfig.buttonTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setButtonTextColor", AndroidUtil.ToAndroidColor(styleConfig.buttonTextColor.Value));
            }
            if (styleConfig.itemPurchaseCashbackTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemPurchaseCashbackTextColor", AndroidUtil.ToAndroidColor(styleConfig.itemPurchaseCashbackTextColor.Value));
            }
            if (styleConfig.itemPurchaseCashbackBackgroundColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemPurchaseCashbackBackgroundColor", AndroidUtil.ToAndroidColor(styleConfig.itemPurchaseCashbackBackgroundColor.Value));
            }
            if (styleConfig.itemPurchaseCashbackHighlightColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemPurchaseCashbackHighlightColor", AndroidUtil.ToAndroidColor(styleConfig.itemPurchaseCashbackHighlightColor.Value));
            }
            if (styleConfig.itemDetailCompleteBorderColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemDetailCompleteBorderColor", AndroidUtil.ToAndroidColor(styleConfig.itemDetailCompleteBorderColor.Value));
            }
            if (styleConfig.itemLimitedRewardTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemLimitedRewardTextColor", AndroidUtil.ToAndroidColor(styleConfig.itemLimitedRewardTextColor.Value));
            }
            if (styleConfig.itemLimitedRewardBorderColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemLimitedRewardBorderColor", AndroidUtil.ToAndroidColor(styleConfig.itemLimitedRewardBorderColor.Value));
            }
            if (styleConfig.promotionRewardTextColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setPromotionRewardTextColor", AndroidUtil.ToAndroidColor(styleConfig.promotionRewardTextColor.Value));
            }
            if (styleConfig.promotionIconColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setPromotionIconColor", AndroidUtil.ToAndroidColor(styleConfig.promotionIconColor.Value));
            }
            if (styleConfig.inboxTimeTitleColor.HasValue)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setInboxTimeTitleColor", AndroidUtil.ToAndroidColor(styleConfig.inboxTimeTitleColor.Value));
            }
            if (styleConfig.featuredBackgroundColors != null)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setFeaturedBackgroundColors", ToAndroidColorList(styleConfig.featuredBackgroundColors));
            }
            if (styleConfig.buttonBackgroundColor != null)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setButtonBackgroundColor", ToAndroidColorList(styleConfig.buttonBackgroundColor));
            }
            if (styleConfig.itemDetailPurchaseCashbackColor != null)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemDetailPurchaseCashbackColor", ToAndroidColorList(styleConfig.itemDetailPurchaseCashbackColor));
            }
            if (styleConfig.itemDetailDailyColor != null)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemDetailDailyColor", ToAndroidColorList(styleConfig.itemDetailDailyColor));
            }
            if (styleConfig.itemLimitedRewardBackgroundColors != null)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setItemLimitedRewardBackgroundColors", ToAndroidColorList(styleConfig.itemLimitedRewardBackgroundColors));
            }
            if (styleConfig.promotionGradientColor != null)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setPromotionGradientColor", ToAndroidColorList(styleConfig.promotionGradientColor));
            }
            if (styleConfig.secondChanceBackgroundColors != null)
            {
                styleConfigBuilder.Call<AndroidJavaObject>("setSecondChanceBackgroundColors", ToAndroidColorList(styleConfig.secondChanceBackgroundColors));
            }

            AndroidJavaObject appsPrizeStyleConfig = styleConfigBuilder.Call<AndroidJavaObject>("build");
            return appsPrizeStyleConfig;
        }

        static AndroidJavaObject ToAndroidColorList(Color[] colors)
        {
            var list = new AndroidJavaObject("java.util.ArrayList");
            foreach (var c in colors)
            {
                list.Call<bool>("add", AndroidUtil.ToAndroidColor(c));
            }
            return list;
        }
    }

}
