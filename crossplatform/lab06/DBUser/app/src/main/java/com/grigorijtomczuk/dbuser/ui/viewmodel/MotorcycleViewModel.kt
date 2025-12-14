package com.grigorijtomczuk.dbuser.ui.viewmodel

import android.app.Application
import android.util.Log
import androidx.lifecycle.AndroidViewModel
import androidx.lifecycle.LiveData
import androidx.lifecycle.viewModelScope
import com.grigorijtomczuk.dbuser.data.db.AppDatabase
import com.grigorijtomczuk.dbuser.data.db.entity.Motorcycle
import com.grigorijtomczuk.dbuser.data.net.RetrofitInstance
import com.grigorijtomczuk.dbuser.data.repository.MotorcycleRepository
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class MotorcycleViewModel(application: Application) : AndroidViewModel(application) {

    private val repository: MotorcycleRepository
    val allMotorcycles: LiveData<List<Motorcycle>>

    init {
        val motorcycleDao = AppDatabase.getDatabase(application).motorcycleDao()
        repository = MotorcycleRepository(motorcycleDao)
        allMotorcycles = repository.allMotorcycles
    }

    fun getMotorcycle(motorcycleId: Int): LiveData<Motorcycle> {
        return repository.getMotorcycle(motorcycleId)
    }

    fun insert(motorcycle: Motorcycle) = viewModelScope.launch {
        repository.insert(motorcycle)
    }

    fun update(motorcycle: Motorcycle) = viewModelScope.launch {
        repository.update(motorcycle)
    }

    fun delete(motorcycle: Motorcycle) = viewModelScope.launch {
        repository.delete(motorcycle)
    }

    fun fetchAndSaveManufacturers() {
        viewModelScope.launch(Dispatchers.IO) {
            try {
                val response = RetrofitInstance.api.getAllManufacturers()
                if (response.isSuccessful) {
                    response.body()?.results?.take(20)?.forEach { manufacturer ->
                        val motorcycle = Motorcycle(
                            brand = manufacturer.name,
                            model = manufacturer.commonName ?: "N/A",
                            year = 2024 // Placeholder year
                        )
                        repository.insert(motorcycle)
                    }
                } else {
                    Log.e("MotorcycleViewModel", "Error fetching manufacturers: ${response.code()}")
                }
            } catch (e: Exception) {
                Log.e("MotorcycleViewModel", "Exception fetching manufacturers", e)
            }
        }
    }
}