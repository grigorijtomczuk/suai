package com.grigorijtomczuk.apiuser.viewmodel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.grigorijtomczuk.apiuser.api.ApiClient
import com.grigorijtomczuk.apiuser.api.Motorcycle
import kotlinx.coroutines.launch

class ManufacturersViewModel : ViewModel() {

    private val _manufacturers = MutableLiveData<List<Motorcycle>>()
    val manufacturers: LiveData<List<Motorcycle>> = _manufacturers

    private val _isLoading = MutableLiveData<Boolean>()
    val isLoading: LiveData<Boolean> = _isLoading

    private val _error = MutableLiveData<String>()
    val error: LiveData<String> = _error

    fun fetchManufacturers() {
        viewModelScope.launch {
            _isLoading.value = true
            try {
                val response = ApiClient.instance.getMotorcycles()
                if (response.isSuccessful && response.body() != null) {
                    _manufacturers.value = response.body()!!.results
                    Log.d("TAG", response.body()!!.results.toString())
                } else {
                    _error.value = "Failed to load manufacturers"
                }
            } catch (e: Exception) {
                _error.value = "No internet connection"
            }
            _isLoading.value = false
        }
    }
}