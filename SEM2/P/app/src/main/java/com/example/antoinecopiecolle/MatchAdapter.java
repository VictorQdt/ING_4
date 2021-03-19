package com.example.antoinecopiecolle;

import android.content.Context;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class MatchAdapter extends RecyclerView.Adapter<com.example.antoinecopiecolle.MatchAdapter.MatchViewHolder> {

    private Context mContext;
    private Cursor mCursor;

    long id_du_match;

    private OnItemClickListener mListener;

    public interface OnItemClickListener{
        void onItemClick(int position, RecyclerView.ViewHolder viewHolder);
    }

    public void setOnItemClickListener(OnItemClickListener listener){
        mListener = listener;
    }

    public MatchAdapter(Context context, Cursor cursor){
        mContext = context;
        mCursor = cursor;
    }

    public class MatchViewHolder extends RecyclerView.ViewHolder{

        public TextView titleRecycleView;
        public TextView descrRecycleView;
        public ImageView imageRecycleView;

        public MatchViewHolder(@NonNull final View itemView) {
            super(itemView);

            titleRecycleView = itemView.findViewById(R.id.title_recycleView);
            descrRecycleView = itemView.findViewById(R.id.description_recycleView);
            imageRecycleView = itemView.findViewById(R.id.image_recycleView);


            itemView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(mListener != null){
                        int position = getAdapterPosition();
                        if(position != RecyclerView.NO_POSITION){
                            mListener.onItemClick(position, MatchViewHolder.this);
                        }
                    }
                }
            });
        }
    }

    @NonNull
    @Override
    public MatchViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(mContext);
        View view = inflater.inflate(R.layout.row, parent, false);
        return new MatchViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MatchViewHolder holder, int position) {
        //Juste pour etre sur que le cursor va bien à la position
        if(!mCursor.moveToPosition(position)){
            return;
        }

        String fighterOne = mCursor.getString(mCursor.getColumnIndex(MatchContract.MatchEntry.COLUMN_NAME_FIGHTER_ONE));
        String fighterTwo = mCursor.getString(mCursor.getColumnIndex(MatchContract.MatchEntry.COLUMN_NAME_FIGHTER_TWO));
        String vainqueur = mCursor.getString(mCursor.getColumnIndex(MatchContract.MatchEntry.COLUMN_NAME_VAINQUEUR));
        String typeVictoire = mCursor.getString(mCursor.getColumnIndex(MatchContract.MatchEntry.COLUMN_NAME_TYPE_VICTOIRE));

        if(mCursor.getBlob(mCursor.getColumnIndex(MatchContract.MatchEntry.IMAGE)) != null){
            Bitmap image = BitmapFactory.decodeByteArray(mCursor.getBlob(mCursor.getColumnIndex(MatchContract.MatchEntry.IMAGE)), 0, mCursor.getBlob(mCursor.getColumnIndex(MatchContract.MatchEntry.IMAGE)).length);
            holder.imageRecycleView.setImageBitmap(image);
        }
        //Blindage du cas où on ne rentre aucune photo --> On en met une par défaut
        else if(mCursor.getBlob(mCursor.getColumnIndex(MatchContract.MatchEntry.IMAGE)) == null){
            holder.imageRecycleView.setImageResource(R.mipmap.ic_launcher_mma);
        }

        //On met aussi l'ID pour pouvoir supprimer quand on swipe
        long id = mCursor.getLong(mCursor.getColumnIndex(MatchContract.MatchEntry._ID));
        id_du_match = id;
        holder.titleRecycleView.setText(fighterOne + " vs " + fighterTwo);
        holder.descrRecycleView.setText("Victoire de " + vainqueur + " par " + typeVictoire);
        holder.itemView.setTag(id);
    }

    @Override
    public int getItemCount() {
        //Return autant de cursor qu'on a dans notre database
        return mCursor.getCount();
    }

    public void swapCursor(Cursor newCursor){
        if(mCursor != null){
            mCursor.close();
        }
        mCursor = newCursor;

        if(newCursor != null){
            notifyDataSetChanged();
        }
    }

    public long getId(){
        return id_du_match;
    }
}
