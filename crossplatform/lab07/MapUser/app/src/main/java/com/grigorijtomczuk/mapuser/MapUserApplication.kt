package com.grigorijtomczuk.mapuser

import android.app.Application
import com.yandex.mapkit.MapKitFactory

class MapUserApplication : Application() {
    override fun onCreate() {
        super.onCreate()
        MapKitFactory.setApiKey("01627e15-d876-4981-b5c0-ec0e0abc534f")
        MapKitFactory.initialize(this)
    }
}
