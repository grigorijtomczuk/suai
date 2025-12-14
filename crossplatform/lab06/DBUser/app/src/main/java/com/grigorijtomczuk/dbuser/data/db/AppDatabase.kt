package com.grigorijtomczuk.dbuser.data.db

import android.content.Context
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import com.grigorijtomczuk.dbuser.data.db.dao.MotorcycleDao
import com.grigorijtomczuk.dbuser.data.db.entity.Motorcycle

@Database(entities = [Motorcycle::class], version = 1, exportSchema = false)
abstract class AppDatabase : RoomDatabase() {

    abstract fun motorcycleDao(): MotorcycleDao

    companion object {
        @Volatile
        private var INSTANCE: AppDatabase? = null

        fun getDatabase(context: Context): AppDatabase {
            return INSTANCE ?: synchronized(this) {
                val instance = Room.databaseBuilder(
                    context.applicationContext,
                    AppDatabase::class.java,
                    "motorcycle_database"
                ).build()
                INSTANCE = instance
                instance
            }
        }
    }
}