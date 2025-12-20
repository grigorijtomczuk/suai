package com.grigorijtomczuk.dbuser

import android.app.AlertDialog
import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.grigorijtomczuk.dbuser.data.Motorcyclist

class DbFragment : Fragment() {

    private lateinit var viewModel: MotorcyclistViewModel
    private lateinit var adapter: MotorcyclistAdapter

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_db, container, false)
        val recyclerView = view.findViewById<RecyclerView>(R.id.recyclerView)
        adapter = MotorcyclistAdapter { motorcyclist -> showOptionsDialog(motorcyclist) }
        recyclerView.adapter = adapter
        recyclerView.layoutManager = LinearLayoutManager(context)

        viewModel = ViewModelProvider(this)[MotorcyclistViewModel::class.java]
        viewModel.allMotorcyclists.observe(viewLifecycleOwner) { motorcyclists ->
            adapter.setMotorcyclists(motorcyclists)
        }

        return view
    }

    private fun showOptionsDialog(motorcyclist: Motorcyclist) {
        val options = arrayOf("Показать", "Обновить", "Удалить")
        AlertDialog.Builder(requireContext())
            .setTitle("Выберите действие")
            .setItems(options) { _, which ->
                when (which) {
                    0 -> showDetails(motorcyclist)
                    1 -> startUpdateActivity(motorcyclist)
                    2 -> startDeleteActivity(motorcyclist)
                }
            }
            .show()
    }

    private fun showDetails(motorcyclist: Motorcyclist) {
        AlertDialog.Builder(requireContext())
            .setTitle("Детали")
            .setMessage("Марка: ${motorcyclist.brand}\nМодель: ${motorcyclist.model}\nГод: ${motorcyclist.year}\nИмя владельца: ${motorcyclist.ownerName}")
            .setPositiveButton("OK", null)
            .show()
    }

    private fun startUpdateActivity(motorcyclist: Motorcyclist) {
        val intent = Intent(requireContext(), UpdateActivity::class.java)
        intent.putExtra("motorcyclist", motorcyclist)
        startActivity(intent)
    }

    private fun startDeleteActivity(motorcyclist: Motorcyclist) {
        val intent = Intent(requireContext(), DeleteActivity::class.java)
        intent.putExtra("motorcyclist", motorcyclist)
        startActivity(intent)
    }
}
