package com.appsprizereactnative

import android.graphics.Color
import android.os.Handler
import android.util.Log
import com.appsamurai.appsprize.AppReward
import com.appsamurai.appsprize.AppsPrize
import com.appsamurai.appsprize.AppsPrizeListener
import com.appsamurai.appsprize.AppsPrizeNotification
import com.appsamurai.appsprize.config.AppsPrizeConfig
import com.appsamurai.appsprize.config.AppsPrizeOfferwallOptions
import com.appsamurai.appsprize.config.AppsPrizeOfferwallType
import com.appsamurai.appsprize.config.style.AppsPrizeStyleConfig
import com.facebook.react.bridge.Arguments
import com.facebook.react.bridge.Callback
import com.facebook.react.bridge.Promise
import com.facebook.react.bridge.ReactApplicationContext
import com.facebook.react.bridge.ReactContextBaseJavaModule
import com.facebook.react.bridge.ReactMethod
import com.facebook.react.modules.core.DeviceEventManagerModule

class AppsprizeReactNativeModule(reactContext: ReactApplicationContext): ReactContextBaseJavaModule(reactContext) {

    override fun getName(): String {
        return NAME
    }

    @ReactMethod
    fun init(raw: String) {
        Handler(reactApplicationContext.mainLooper).post {
            val map = jsonStringToMap(raw)?.get("config") as? Map<String, Any?> ?: return@post
            Log.d("[AppsPrizeAndroid]", "init with config $map")

            val appsPrizeConfig = buildConfig(map) ?: return@post
            AppsPrize.initialize(reactApplicationContext, appsPrizeConfig, object: AppsPrizeListener {
                override fun onInitialize() {
                    Log.d("[AppsPrizeAndroid]", "onInitialize")
                    sendEvent(Events.OnInitialize)
                }

                override fun onInitializeFailed(errorMessage: String) {
                    Log.d("[AppsPrizeAndroid]", "onInitializeFailed: $errorMessage")
                    sendEvent(Events.OnInitializeFailed, mapOf(
                        "errorMessage" to errorMessage
                    ))
                }

                override fun onRewardUpdate(rewards: List<AppReward>) {
                    Log.d("[AppsPrizeAndroid]", " onRewardUpdate: $rewards")
                    sendEvent(Events.OnRewardUpdate, mapOf(
                        "rewards" to rewards.map {
                            createAppReward(it)
                        }
                    ))
                }

                override fun onNotification(notifications: List<AppsPrizeNotification>) {
                    Log.d("[AppsPrizeAndroid]", " onNotification: $notifications")
                    sendEvent(Events.OnNotification, mapOf(
                        "notifications" to notifications.map {
                            createNotification(it)
                        }
                    ))
                }
            })
        }
    }

    @ReactMethod
    fun launch(raw: String, promise: Promise) {
        Log.d("[AppsPrizeAndroid]", " launch()")
        val activity = currentActivity ?: run {
            promise.reject(Exception("AppsPrize:Android: no current activity found"))
            return
        }
        Handler(activity.mainLooper).post {
            val map = jsonStringToMap(raw)?.get("options") as? Map<String, Any?>
            Log.d("[AppsPrizeAndroid]", "launch options $map")
            val offerwallOptions = buildOptions(map)
            val result = AppsPrize.launchActivity(activity, offerwallOptions)
            promise.resolve(result)
        }
    }

    @ReactMethod
    fun open(campaignId: Int, promise: Promise) {
        Log.d("[AppsPrizeAndroid]", " open()")
        val activity = currentActivity ?: run {
            promise.reject(Exception("AppsPrize:Android: no current activity found"))
            return
        }
        Handler(activity.mainLooper).post {
            val result = AppsPrize.open(activity, campaignId)
            promise.resolve(result)
        }
    }


    @ReactMethod
    fun doReward(callback: Callback) {
        Log.d("[AppsPrizeAndroid]", " doReward()")
        val activity = currentActivity ?: return
        Handler(activity.mainLooper).post {
            AppsPrize.doReward(activity) { rewards ->
                val appRewardsMap = rewards.mapNotNull { createAppReward(it) }
                callback.invoke(mapToJsonString(mapOf(
                    "rewards" to appRewardsMap
                )))
            }
        }
    }

    @ReactMethod
    fun hasPermissions(promise: Promise) {
        Log.d("[AppsPrizeAndroid]", " hasPermissions()")
        val activity = currentActivity ?: run {
            promise.reject(Exception("AppsPrize:Android: no current activity found"))
            return
        }
        Handler(activity.mainLooper).post {
            val result = AppsPrize.hasPermissions(activity)
            promise.resolve(result)
        }
    }

    @ReactMethod
    fun requestPermission(promise: Promise) {
        Log.d("[AppsPrizeAndroid]", " requestPermission()")
        val activity = currentActivity ?: run {
            promise.reject(Exception("AppsPrize:Android: no current activity found"))
            return
        }
        Handler(activity.mainLooper).post {
            val result = AppsPrize.requestPermission(activity)
            promise.resolve(result)
        }
    }

    @ReactMethod
    fun addListener(eventName: String?) {
        Log.d("[AppsPrizeAndroid]", " addListener:eventName:${eventName}")
    }

    @ReactMethod
    fun removeListeners(count: Int?) {
        Log.d("[AppsPrizeAndroid]", " removeListeners:count:${count}")
    }

    private fun createAppReward(reward: AppReward): Map<String, Any?> {
        return mapOf(
            "rewards" to reward.rewards.map {
                mapOf(
                    "currency" to it.currency,
                    "level" to it.level,
                    "points" to it.points,
                )
            }
        )
    }

    private fun createNotification(reward: AppsPrizeNotification): Map<String, Any?> {
        return mapOf(
            "id" to reward.id,
            "campaignId" to reward.campaignId,
            "appName" to reward.appName,
            "description" to reward.description,
            "hasRead" to reward.hasRead,
            "iconUrl" to reward.iconUrl,
            "timestamp" to reward.timestamp,
        )
    }

    private fun buildConfig(map: Map<String, Any?>): AppsPrizeConfig? {
        val token = map["token"] as? String ?: return null
        val advertisingId =  map["advertisingId"] as? String ?: return null
        val userId =  map["userId"] as? String ?: return null
        val country = map["country"] as? String
        val language = map["language"] as? String
        val gender = map["gender"] as? String?
        val age = map["age"] as? Int?
        val uaChannel = map["uaChannel"] as? String?
        val uaNetwork = map["uaNetwork"] as? String?
        val adPlacement = map["adPlacement"] as? String?

        return AppsPrizeConfig.Builder()
            .setCountry(country)
            .setLanguage(language)
            .setStyle(buildStyleConfig(map["style"] as? Map<String, Any?>))
            .setGender(gender)
            .setAge(age)
            .setUaChannel(uaChannel)
            .setUaNetwork(uaNetwork)
            .setAdPlacement(adPlacement)
            .build(
                token,
                advertisingId,
                userId
            )
    }

    private fun buildStyleConfig(map: Map<String, Any?>?): AppsPrizeStyleConfig? {
        map ?: return null

        val typeface = getTypeface(reactApplicationContext, map["typeface"] as? String)
        val bannerDrawable = getDrawable(reactApplicationContext, map["bannerDrawable"] as? String)
        val offersTitleText = map["offersTitleText"] as? String
        val appsTitleText = map["appsTitleText"] as? String
        val currencyIcon = getDrawable(reactApplicationContext, map["currencyIcon"] as? String)

        val screenBackgroundColor = (map["screenBackgroundColor"] as? String)?.let { Color.parseColor(it) }
        val primaryTextColor = (map["primaryTextColor"] as? String)?.let { Color.parseColor(it) }
        val onboardingBackgroundColor = (map["onboardingBackgroundColor"] as? String)?.let { Color.parseColor(it) }
        val bottomFloatingBackgroundColor = (map["bottomFloatingBackgroundColor"] as? String)?.let { Color.parseColor(it) }
        val bottomFloatingBorderColor = (map["bottomFloatingBorderColor"] as? String)?.let { Color.parseColor(it) }
        val bottomNavigationTextColor = (map["bottomNavigationTextColor"] as? String)?.let { Color.parseColor(it) }
        val bottomNavigationActiveColor = (map["bottomNavigationActiveColor"] as? String)?.let { Color.parseColor(it) }
        val itemTitleTextColor = (map["itemTitleTextColor"] as? String)?.let { Color.parseColor(it) }
        val itemCategoryTextColor = (map["itemCategoryTextColor"] as? String)?.let { Color.parseColor(it) }
        val itemImageBorderColor = (map["itemImageBorderColor"] as? String)?.let { Color.parseColor(it) }
        val itemBackgroundColor = (map["itemBackgroundColor"] as? String)?.let { Color.parseColor(it) }
        val itemBorderColor = (map["itemBorderColor"] as? String)?.let { Color.parseColor(it) }
        val itemProgressColor = (map["itemProgressColor"] as? String)?.let { Color.parseColor(it) }
        val itemProgressBackgroundColor = (map["itemProgressBackgroundColor"] as? String)?.let { Color.parseColor(it) }
        val appsSelectItemBackgroundColor = (map["appsSelectItemBackgroundColor"] as? String)?.let { Color.parseColor(it) }
        val buttonTextColor = (map["buttonTextColor"] as? String)?.let { Color.parseColor(it) }
        val itemPurchaseCashbackTextColor = (map["itemPurchaseCashbackTextColor"] as? String)?.let { Color.parseColor(it) }
        val itemPurchaseCashbackBackgroundColor = (map["itemPurchaseCashbackBackgroundColor"] as? String)?.let { Color.parseColor(it) }
        val itemPurchaseCashbackHighlightColor = (map["itemPurchaseCashbackHighlightColor"] as? String)?.let { Color.parseColor(it) }
        val itemDetailCompleteBorderColor = (map["itemDetailCompleteBorderColor"] as? String)?.let { Color.parseColor(it) }
        val itemLimitedRewardTextColor = (map["itemLimitedRewardTextColor"] as? String)?.let { Color.parseColor(it) }
        val itemLimitedRewardBorderColor = (map["itemLimitedRewardBorderColor"] as? String)?.let { Color.parseColor(it) }
        val promotionRewardTextColor = (map["promotionRewardTextColor"] as? String)?.let { Color.parseColor(it) }
        val promotionIconColor = (map["promotionIconColor"] as? String)?.let { Color.parseColor(it) }
        val inboxTimeTitleColor = (map["inboxTimeTitleColor"] as? String)?.let { Color.parseColor(it) }

        val featuredBackgroundColors = (map["featuredBackgroundColors"] as? List<*>)
            ?.mapNotNull { (it as? String)?.let { s -> Color.parseColor(s) } }
        val buttonBackgroundColor = (map["buttonBackgroundColor"] as? List<*>)
            ?.mapNotNull { (it as? String)?.let { s -> Color.parseColor(s) } }
        val itemDetailPurchaseCashbackColor = (map["itemDetailPurchaseCashbackColor"] as? List<*>)
            ?.mapNotNull { (it as? String)?.let { s -> Color.parseColor(s) } }
        val itemDetailDailyColor = (map["itemDetailDailyColor"] as? List<*>)
            ?.mapNotNull { (it as? String)?.let { s -> Color.parseColor(s) } }
        val itemLimitedRewardBackgroundColors = (map["itemLimitedRewardBackgroundColors"] as? List<*>)
            ?.mapNotNull { (it as? String)?.let { s -> Color.parseColor(s) } }
        val promotionGradientColor = (map["promotionGradientColor"] as? List<*>)
            ?.mapNotNull { (it as? String)?.let { s -> Color.parseColor(s) } }
        val secondChanceBackgroundColors = (map["secondChanceBackgroundColors"] as? List<*>)
            ?.mapNotNull { (it as? String)?.let { s -> Color.parseColor(s) } }

        return AppsPrizeStyleConfig.Builder()
            .setTypeface(typeface)
            .setBannerDrawable(bannerDrawable)
            .setOffersTitleText(offersTitleText)
            .setAppsTitleText(appsTitleText)
            .setCurrencyIcon(currencyIcon)
            .setScreenBackgroundColor(screenBackgroundColor)
            .setPrimaryTextColor(primaryTextColor)
            .setOnboardingBackgroundColor(onboardingBackgroundColor)
            .setBottomFloatingBackgroundColor(bottomFloatingBackgroundColor)
            .setBottomFloatingBorderColor(bottomFloatingBorderColor)
            .setBottomNavigationTextColor(bottomNavigationTextColor)
            .setBottomNavigationActiveColor(bottomNavigationActiveColor)
            .setItemTitleTextColor(itemTitleTextColor)
            .setItemCategoryTextColor(itemCategoryTextColor)
            .setItemImageBorderColor(itemImageBorderColor)
            .setItemBackgroundColor(itemBackgroundColor)
            .setItemBorderColor(itemBorderColor)
            .setItemProgressColor(itemProgressColor)
            .setItemProgressBackgroundColor(itemProgressBackgroundColor)
            .setAppsSelectItemBackgroundColor(appsSelectItemBackgroundColor)
            .setButtonTextColor(buttonTextColor)
            .setItemPurchaseCashbackTextColor(itemPurchaseCashbackTextColor)
            .setItemPurchaseCashbackBackgroundColor(itemPurchaseCashbackBackgroundColor)
            .setItemPurchaseCashbackHighlightColor(itemPurchaseCashbackHighlightColor)
            .setItemDetailCompleteBorderColor(itemDetailCompleteBorderColor)
            .setItemLimitedRewardTextColor(itemLimitedRewardTextColor)
            .setItemLimitedRewardBorderColor(itemLimitedRewardBorderColor)
            .setPromotionRewardTextColor(promotionRewardTextColor)
            .setPromotionIconColor(promotionIconColor)
            .setInboxTimeTitleColor(inboxTimeTitleColor)
            .setFeaturedBackgroundColors(featuredBackgroundColors)
            .setButtonBackgroundColor(buttonBackgroundColor)
            .setItemDetailPurchaseCashbackColor(itemDetailPurchaseCashbackColor)
            .setItemDetailDailyColor(itemDetailDailyColor)
            .setItemLimitedRewardBackgroundColors(itemLimitedRewardBackgroundColors)
            .setPromotionGradientColor(promotionGradientColor)
            .setSecondChanceBackgroundColors(secondChanceBackgroundColors)
            .build()
    }


    private fun buildOptions(map: Map<String, Any?>?): AppsPrizeOfferwallOptions {
        val type = (map?.get("type") as? String)?.uppercase()?.let {
            try { AppsPrizeOfferwallType.valueOf(it) } catch (_: Exception) { null }
        }
        return AppsPrizeOfferwallOptions.Builder()
            .setType(type)
            .build()
    }


    private fun sendEvent(event: Events, map: Map<String, Any?>? = null) {
        val raw = mapToJsonString(map)
        reactApplicationContext
            .getJSModule(DeviceEventManagerModule.RCTDeviceEventEmitter::class.java)
            .emit(event.description, Arguments.createMap().apply {
                putString("raw", raw)
            })
    }

    private enum class Events(val description: String) {
        OnInitialize("onInitialize"),
        OnInitializeFailed("onInitializeFailed"),
        OnRewardUpdate("onRewardUpdate"),
        OnNotification("onNotification");
    }

    companion object {
        const val NAME = "AppsprizeReactNative"
    }
}

