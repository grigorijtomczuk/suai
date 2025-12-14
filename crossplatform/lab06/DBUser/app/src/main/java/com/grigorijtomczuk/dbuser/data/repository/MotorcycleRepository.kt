package com.grigorijtomczuk.dbuser.data.repository

import androidx.lifecycle.LiveData
import com.grigorijtomczuk.dbuser.data.db.dao.MotorcycleDao
import com.grigorijtomczuk.dbuser.data.db.entity.Motorcycle

class MotorcycleRepository(private val motorcycleDao: MotorcycleDao) {

    val allMotorcycles: LiveData<List<Motorcycle>> = motorcycleDao.getAllMotorcycles()

    fun getMotorcycle(motorcycleId: Int): LiveData<Motorcycle> {
        return motorcycleDao.getMotorcycle(motorcycleId)
    }

    suspend fun insert(motorcycle: Motorcycle) {
        motorcycleDao.insert(motorcycle)
    }

    suspend fun update(motorcycle: Motorcycle) {
        motorcycleDao.update(motorcycle)
    }

    suspend fun delete(motorcycle: Motorcycle) {
        motorcycleDao.delete(motorcycle)
    }
}