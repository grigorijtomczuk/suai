package com.grigorijtomczuk.apiuser.ui.manufacturers

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.grigorijtomczuk.apiuser.api.Manufacturer
import com.grigorijtomczuk.apiuser.databinding.ManufacturerItemBinding

class ManufacturersAdapter(private var manufacturers: List<Manufacturer>) : RecyclerView.Adapter<ManufacturersAdapter.ManufacturerViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ManufacturerViewHolder {
        val binding = ManufacturerItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return ManufacturerViewHolder(binding)
    }

    override fun onBindViewHolder(holder: ManufacturerViewHolder, position: Int) {
        val manufacturer = manufacturers[position]
        holder.bind(manufacturer)
    }

    override fun getItemCount() = manufacturers.size

    fun updateData(manufacturers: List<Manufacturer>) {
        this.manufacturers = manufacturers
        notifyDataSetChanged()
    }

    inner class ManufacturerViewHolder(private val binding: ManufacturerItemBinding) : RecyclerView.ViewHolder(binding.root) {
        fun bind(manufacturer: Manufacturer) {
            binding.manufacturerName.text = manufacturer.name
            binding.manufacturerCountry.text = manufacturer.country
        }
    }
}