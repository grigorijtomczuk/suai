package com.grigorijtomczuk.dbuser.data

import androidx.lifecycle.LiveData

class MotorcyclistRepository(private val motorcyclistDao: MotorcyclistDao) {
    val allMotorcyclists: LiveData<List<Motorcyclist>> = motorcyclistDao.getAll()

    suspend fun insert(motorcyclist: Motorcyclist) {
        motorcyclistDao.insert(motorcyclist)
    }

    suspend fun update(motorcyclist: Motorcyclist) {
        motorcyclistDao.update(motorcyclist)
    }

    suspend fun delete(motorcyclist: Motorcyclist) {
        motorcyclistDao.delete(motorcyclist)
    }
}
