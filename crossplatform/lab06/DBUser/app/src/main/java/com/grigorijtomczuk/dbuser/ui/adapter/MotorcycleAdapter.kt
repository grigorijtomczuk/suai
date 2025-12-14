package com.grigorijtomczuk.dbuser.ui.adapter

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.grigorijtomczuk.dbuser.R
import com.grigorijtomczuk.dbuser.data.db.entity.Motorcycle

class MotorcycleAdapter(
    private val onLongClickListener: (Motorcycle) -> Unit
) : RecyclerView.Adapter<MotorcycleAdapter.MotorcycleViewHolder>() {

    private var motorcycles = emptyList<Motorcycle>()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MotorcycleViewHolder {
        val itemView = LayoutInflater.from(parent.context).inflate(R.layout.item_motorcycle, parent, false)
        return MotorcycleViewHolder(itemView)
    }

    override fun onBindViewHolder(holder: MotorcycleViewHolder, position: Int) {
        val currentMotorcycle = motorcycles[position]
        holder.bind(currentMotorcycle)
        holder.itemView.setOnLongClickListener {
            onLongClickListener(currentMotorcycle)
            true
        }
    }

    override fun getItemCount() = motorcycles.size

    fun setMotorcycles(motorcycles: List<Motorcycle>) {
        this.motorcycles = motorcycles
        notifyDataSetChanged()
    }

    class MotorcycleViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        private val brandTextView: TextView = itemView.findViewById(R.id.tv_brand)
        private val modelTextView: TextView = itemView.findViewById(R.id.tv_model)
        private val yearTextView: TextView = itemView.findViewById(R.id.tv_year)

        fun bind(motorcycle: Motorcycle) {
            brandTextView.text = motorcycle.brand
            modelTextView.text = motorcycle.model
            yearTextView.text = motorcycle.year.toString()
        }
    }
}