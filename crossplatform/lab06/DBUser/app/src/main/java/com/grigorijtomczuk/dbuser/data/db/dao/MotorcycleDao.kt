package com.grigorijtomczuk.dbuser.data.db.dao

import androidx.lifecycle.LiveData
import androidx.room.Dao
import androidx.room.Delete
import androidx.room.Insert
import androidx.room.Query
import androidx.room.Update
import com.grigorijtomczuk.dbuser.data.db.entity.Motorcycle

@Dao
interface MotorcycleDao {
    @Insert
    suspend fun insert(motorcycle: Motorcycle)

    @Update
    suspend fun update(motorcycle: Motorcycle)

    @Delete
    suspend fun delete(motorcycle: Motorcycle)

    @Query("SELECT * FROM motorcycles")
    fun getAllMotorcycles(): LiveData<List<Motorcycle>>

    @Query("SELECT * FROM motorcycles WHERE id = :motorcycleId")
    fun getMotorcycle(motorcycleId: Int): LiveData<Motorcycle>
}