package com.grigorijtomczuk.dbuser

import android.app.Application
import com.grigorijtomczuk.dbuser.data.AppDatabase

class DBUserApplication : Application() {
    val database by lazy { AppDatabase.getDatabase(this) }
}
